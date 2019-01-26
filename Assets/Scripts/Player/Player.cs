using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk
    }

    #region Getter
    public Collider Collider { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    #endregion

    #region SerializeField
    [SerializeField]
    private PlayerView playerView;
    [SerializeField]
    private PlayerStateMachine stateMachine;

    [Header("Interaction")]
    [SerializeField]
    private float interactionRadius = 2f;
    [SerializeField]
    private LayerMask interactableMask;
    private Interactable closerInteractable;

    [Space]
    [SerializeField]
    private float speed = 10f;
    public float Speed
    {
        get { return speed; }
    }
    #endregion

    public Vector3 Direction { get; private set; }
    public void SetDirection(Vector3 direction)
    {
        this.Direction = (direction.sqrMagnitude > 1f ? direction.normalized : direction);
    }

    private void Awake()
    {
        Collider = GetComponent<Collider>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine.FillStates(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState != GameManager.State.Game)
        {
            return;
        }
        stateMachine.Update();
        HandleSelectable();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    private void LateUpdate()
    {
        if (closerInteractable != null)
        {
            closerInteractable.OnEnableInteraction();
        }
    }

    private void HandleSelectable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius);
        IEnumerable<Interactable> interactables = colliders.Select(c => c.GetComponent<Interactable>()).Where(i => i != null);
        if (interactables.Count() != 0)
        {
            closerInteractable = interactables.Aggregate((minN, n) => Vector3.SqrMagnitude(transform.position - n.transform.position) < Vector3.SqrMagnitude(transform.position - minN.transform.position) ? n : minN);
        } else
        {
            closerInteractable = null;
        }
    }

    public void Interact()
    {
        if (closerInteractable != null)
        {
            closerInteractable.OnInteraction(new Interactable.Interaction
            {
                player = this
            });
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}

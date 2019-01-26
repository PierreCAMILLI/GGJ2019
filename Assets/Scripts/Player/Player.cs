using System.Collections;
using System.Collections.Generic;
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

    [SerializeField]
    private float speed;
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
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
}

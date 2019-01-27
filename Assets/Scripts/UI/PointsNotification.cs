using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsNotification : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private int pointsEarned = 0;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    private void UpdateText(float opacity)
    {
        char ope = ' ';
        Color c = Color.clear;
        if (pointsEarned > 0)
        {
            ope = '+';
            c = Color.green;
        } else if (pointsEarned < 0)
        {
            ope = '-';
            c = Color.red;
        }
        c.a = opacity;
        text.color = c;
        text.text = ope + pointsEarned.ToString();

        text.rectTransform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void SetPoints(int points)
    {
        pointsEarned = points;
    }

    public void Play()
    {
        UpdateText(0f);
        animator.SetTrigger("Display");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdContact : LoadMonoBehaviour
{
    [Header("Bird Contact")]
    [SerializeField] protected CircleCollider2D circleCollider;
    public CircleCollider2D CircleCollider => circleCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": LoadCircleCollider2D", gameObject);
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Instance.IsGameOver) return;
        SoundsManager.Instance.PlayHit();
        GameManager.Instance.GameOver();
    }
}

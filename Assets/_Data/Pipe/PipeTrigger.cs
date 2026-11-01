using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PipeTrigger : LoadMonoBehaviour
{
    [Header("Pipe Trigger")]
    [SerializeField] protected BoxCollider2D boxCollider2D;
    public BoxCollider2D BoxCollider2D => this.boxCollider2D;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider2D();
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = transform.GetComponent<BoxCollider2D>();
        Debug.LogWarning(transform.name + ": LoadBoxCollider2D", gameObject);

        this.boxCollider2D.isTrigger = true;
        this.boxCollider2D.offset = new Vector2(0.25f, 0);
        //this.boxCollider2D.size = new Vector2(0.5f, 3.6f);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        SoundsManager.Instance.PlayPoint();
        GameManager.Instance.AddScore();
    }
}

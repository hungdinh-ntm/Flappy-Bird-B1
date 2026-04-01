using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGravity : BirdAbstract
{
    [Header("Bird Gravity")]
    [SerializeField] protected float normalGravity = 1f;

    protected override void Start()
    {
        this.SetGravity();
    }

    public virtual void SetGravity()
    {
        this.BirdCtrl.Rigid2D.gravityScale = 0;
    }

    public virtual void GravityScale()
    {
        this.BirdCtrl.Rigid2D.gravityScale = this.normalGravity;
    }

    public virtual void StopBird()
    {
        this.birdCtrl.Rigid2D.velocity = Vector2.zero;
        float currentZ = transform.eulerAngles.z;

        this.birdCtrl.Rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        transform.rotation = Quaternion.Euler(0, 0, currentZ);
        this.SetGravity();
    }
}

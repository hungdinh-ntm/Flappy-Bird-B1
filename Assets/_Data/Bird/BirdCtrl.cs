using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtrl : LoadMonoBehaviour
{
    [Header("Bird Ctrl")]
    private static BirdCtrl instance;
    public static BirdCtrl Instance => instance;

    [SerializeField] protected AbilityFly abilityFly;
    public AbilityFly AbilityFly => abilityFly;

    [SerializeField] protected BirdGravity birdGravity;
    public BirdGravity BirdGravity => birdGravity;

    [SerializeField] protected Rigidbody2D rigid2D;
    public Rigidbody2D Rigid2D => rigid2D;

    protected override void Awake()
    {
        if (BirdCtrl.instance != null) Debug.LogError("Only 1 BirdCtrl allow to exist");
        BirdCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityFly();
        this.LoadBirdGravity();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadAbilityFly()
    {
        if (this.abilityFly != null) return;
        this.abilityFly = transform.GetComponentInChildren<AbilityFly>();
        Debug.LogWarning(transform.name + ": LoadAbilityFly", gameObject);
    }

    protected virtual void LoadBirdGravity()
    {
        if (this.birdGravity != null) return;
        this.birdGravity = transform.GetComponentInChildren<BirdGravity>();
        Debug.LogWarning(transform.name + ": LoadBirdGravity", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rigid2D != null) return;
        this.rigid2D = transform.GetComponentInParent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BirdAbstract : LoadMonoBehaviour
{
    [Header("Bird Abstract")]
    [SerializeField] protected BirdCtrl birdCtrl;
    public BirdCtrl BirdCtrl => birdCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBirdCtrl();
    }

    protected virtual void LoadBirdCtrl()
    {
        if (this.birdCtrl != null) return;
        this.birdCtrl = transform.GetComponentInParent<BirdCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}

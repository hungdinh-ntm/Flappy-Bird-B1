using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected Transform mainCamera;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float disLimit = 20;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = FindAnyObjectByType<Camera>().transform;
        Debug.Log(transform.parent.name + ": Load Camera", gameObject);
    }

    protected override bool CheckCanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCamera.position);
        //Debug.Log("Distance: " + this.distance);
        if (this.distance > this.disLimit) return true;
        return false;
    }

}

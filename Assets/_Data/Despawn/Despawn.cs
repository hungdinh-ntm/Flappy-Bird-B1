using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : LoadMonoBehaviour
{
    //[Header("Despawn")]
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CheckCanDespawn()) return;
        this.DespawnObj();
    }

    protected virtual void DespawnObj()
    {
        Debug.Log("Despawn");
    }

    protected abstract bool CheckCanDespawn();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnCtrl : LoadMonoBehaviour
{
    [Header("Pipe Spawn Ctrl")]
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => spawnPoint;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.spawnPoint = transform.GetComponentInChildren<SpawnPoint>();
    }
}

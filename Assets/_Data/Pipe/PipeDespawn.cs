using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDespawn : DespawnByDistance
{
    protected override void DespawnObj()
    {
        PipeSpawner.Instance.MoveBackPools(transform.parent);
    }
}

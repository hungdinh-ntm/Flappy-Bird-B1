using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : LoadMonoBehaviour
{
    [Header("Spawn Point")]
    [SerializeField] protected Transform point;
    public Transform Point => point;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (this.point != null) return;
        this.point = transform.Find("Point_1");
    }
}

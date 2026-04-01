using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : Spawner
{
    [Header("Spawner")]
    private static PipeSpawner instance;
    public static PipeSpawner Instance => instance;

    public static string PipeOne = "Pipe";

    protected override void Awake()
    {
        base.Awake();
        if (PipeSpawner.instance != null) Debug.LogError("Only 1 PipeSpawner allow to exist");
        PipeSpawner.instance = this;
    }
}

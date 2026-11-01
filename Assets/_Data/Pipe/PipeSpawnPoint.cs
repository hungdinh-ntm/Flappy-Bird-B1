using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnPoint : LoadMonoBehaviour
{
    [Header("Pipe Spawn Point")]
    [SerializeField] protected PipeSpawnCtrl pipeSpawnCtrl;

    [SerializeField] protected float spawnDelay = 1.5f;
    [SerializeField] protected float spawnTimer = 0f;
    public float minY = -2f;
    public float maxY = 2f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPipeSpawnCtrl();
    }

    protected virtual void LoadPipeSpawnCtrl()
    {
        if (this.pipeSpawnCtrl != null) return;
        this.pipeSpawnCtrl = GetComponent<PipeSpawnCtrl>();
    }

    private void FixedUpdate()
    {
        this.PipeSpawning();
    }

    protected virtual void PipeSpawning()
    {
        if (!GameManager.Instance.IsGameStarted) return;
        if (GameManager.Instance.IsGameOver) return;

        this.spawnTimer += Time.fixedDeltaTime;
        if (this.spawnTimer < this.spawnDelay) return;

        Transform pointObj = this.pipeSpawnCtrl.SpawnPoint.Point;
        Vector3 pos = pointObj.position;
        pos.y = Random.Range(this.minY, this.maxY);
        Quaternion rot = pointObj.rotation;

        string prefabName = PipeSpawner.PipeOne;

        //Debug.Log("pos: " + pos.y);
        Transform newObj = PipeSpawner.Instance.Spawn(prefabName, pos, rot);
        newObj.gameObject.SetActive(true);

        newObj.GetComponentInChildren<PipeRanSpace>().SetSpace();
        this.spawnTimer = 0f;
    }
}

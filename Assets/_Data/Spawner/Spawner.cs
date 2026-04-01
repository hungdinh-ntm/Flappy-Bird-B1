using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : LoadMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
        this.LoadPrefabs();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefab();
    }

    protected virtual void HidePrefab()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("Prefab not found: " + prefabName);
            return null;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newPrefab = this.GetObjFrommPool(prefab);

        newPrefab.SetLocalPositionAndRotation(spawnPos, spawnRot);
        newPrefab.SetParent(this.holder);

        this.spawnedCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjFrommPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual void MoveBackPools(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }
}

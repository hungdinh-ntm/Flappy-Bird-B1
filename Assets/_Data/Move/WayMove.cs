using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayMove : LoadMonoBehaviour
{
    [Header("Way Move")]
    [SerializeField] protected int speedMove = 3;

    private void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        if (GameManager.Instance.IsGameOver) return;
        transform.parent.Translate(Vector3.left * speedMove * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : LoadMonoBehaviour
{
    [Header("UI Game Over")]
    [SerializeField] protected UIResult uiResult;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIResult();
    }

    protected virtual void LoadUIResult()
    {
        if (this.uiResult != null) return;
        this.uiResult = GetComponentInChildren<UIResult>();
        Debug.LogWarning(transform.name + ": LoadUIResult", gameObject);
    }

    public virtual void ShowResult(int score)
    {
        transform.gameObject.SetActive(true);
        this.uiResult.SetScore(score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : LoadMonoBehaviour
{
    [SerializeField] protected Transform UIInstruct;
    [SerializeField] protected Transform UITopCenter;

    private void Update()
    {
        this.HideUI();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIInstruct();
        this.LoadUITopCenter();
    }

    protected virtual void LoadUIInstruct()
    {
        if (this.UIInstruct != null) return;
        this.UIInstruct = GameObject.Find("UIInstruct").transform;
    }

    protected virtual void LoadUITopCenter()
    {
        if (this.UITopCenter != null) return;
        this.UITopCenter = GameObject.Find("UITopCenter").transform;
        this.UITopCenter.gameObject.SetActive(false);
    }

    protected virtual void HideUI()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            this.UIInstruct.gameObject.SetActive(false);
            this.UITopCenter.gameObject.SetActive(true);
        }
    }
}

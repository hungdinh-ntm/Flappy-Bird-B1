using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : LoadMonoBehaviour
{
    [Header("UI Score")]
    [SerializeField] protected TextMeshProUGUI numScore;
    public TextMeshProUGUI NumScore => numScore;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadNumScore();
    }

    protected virtual void LoadNumScore()
    {
        if (this.numScore != null) return;
        this.numScore = transform.Find("NumScore").GetComponent<TextMeshProUGUI>();
        //Debug.LogWarning(transform.name + ": LoadNumScore", gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResult : LoadMonoBehaviour
{
    [Header("UI Result")]
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
        Debug.LogWarning(transform.name + ": LoadNumScore", gameObject);
    }

    public virtual void SetScore(int score)
    {
        this.numScore.text = score.ToString();
    }
}

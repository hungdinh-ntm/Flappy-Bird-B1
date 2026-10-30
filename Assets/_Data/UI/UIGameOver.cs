using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : LoadMonoBehaviour
{
    [Header("UI Game Over")]
    [SerializeField] protected UIResultScore uiResult;
    [SerializeField] protected UIHighScore uiHighScore;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIResult();
        this.LoadUIHighScore();
    }

    protected virtual void LoadUIResult()
    {
        if (this.uiResult != null) return;
        this.uiResult = GetComponentInChildren<UIResultScore>();
        //Debug.LogWarning(transform.name + ": LoadUIResult", gameObject);
    }

    protected virtual void LoadUIHighScore()
    {
        if (this.uiHighScore != null) return;
        this.uiHighScore = GetComponentInChildren<UIHighScore>();
        //Debug.LogWarning(transform.name + ": LoadUIHighScore", gameObject);
    }

    public virtual void ShowResult(int score)
    {
        transform.gameObject.SetActive(true);
        this.uiResult.SetScore(score);

        int bestScore = SaveManager.LoadBestScore();
        Debug.Log("Best Score: " + bestScore);
        this.uiHighScore.SetHighScore(bestScore);
    }
}

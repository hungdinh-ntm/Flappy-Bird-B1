using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScore : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateScore();
    }

    protected virtual void UpdateScore()
    {
        int score = GameManager.Instance.GameScore;
        this.text.SetText(score.ToString());
    }
}

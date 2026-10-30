using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHighScore : UIScore
{
    public virtual void SetHighScore(int score)
    {
        this.numScore.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResultScore : UIScore
{
    //[Header("UI Result")]

    public virtual void SetScore(int score)
    {
        this.numScore.text = score.ToString();
    }
}

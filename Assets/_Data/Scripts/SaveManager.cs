using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : LoadMonoBehaviour
{
    private const string KEY_BEST_SCORE = "BestScore";

    public static void SaveBestScore(int score)
    {
        int bestScore = LoadBestScore();

        if (score > bestScore)
        {
            PlayerPrefs.SetInt(KEY_BEST_SCORE, score);
            PlayerPrefs.Save();
        }
    }

    public static int LoadBestScore()
    {
        return PlayerPrefs.GetInt(KEY_BEST_SCORE, 0);
    }
}

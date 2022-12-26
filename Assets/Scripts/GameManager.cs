using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text Scores;
    public int Score { get; set; }

    private void Start()
    {
        int storedScore = PlayerPrefs.GetInt("Highscore", 0);
        Scores.text = $"SCORE : {storedScore}";
    }

    public void IncrementScore(int value)
    {
        Score += value;

        if (Score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", Score);
            Scores.text = $"SCORE : {Score}";
        }
    }
}

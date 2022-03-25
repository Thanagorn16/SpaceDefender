using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    public int CurrentScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue); // do this so the score won't be below 0 // at the same time this return nothing so what's the point of doing this as it does nothing   
        // Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}

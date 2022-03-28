using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    // static UIGameOver instance;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        // Debug.Log(scoreKeeper);
    }

    void Start()
    {
        scoreText.text = "Scored: \n" + scoreKeeper.CurrentScore().ToString();
        // Debug.Log(scoreText);
        // Debug.Log(scoreKeeper.CurrentScore());
        // Debug.Log(scoreKeeper);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    
    /// <summary>
    /// The game state object with the score
    /// </summary>
    public GameStateScript GameState;

    void Start()
    {
        GameState.Score = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + GameState.Score;
    }
}

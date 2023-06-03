using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    
    /// <summary>
    /// Set automatically
    /// </summary>
    public GameStateScript GameState;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + GameState.Score;
    }
}

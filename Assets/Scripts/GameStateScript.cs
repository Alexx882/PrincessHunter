using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameStateScript : MonoBehaviour
{
    private int _score;

    /// <summary>
    /// Manages the score and its UI
    /// </summary>
    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            ScoreText.text = "Score: " + value;
        }
    }

    public Camera Camera;
    public TextMeshProUGUI CountdownText;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverUI;

    private bool _gameOver = false;
    public bool GameOver
    { 
        get => _gameOver;
        private set
        {
            _gameOver = value;
            GameOverUI.SetActive(value);
        }
    }

    public float countdownTime = 30f;
    private float remainingTime;

    public Vector3[] Points;

    public GameObject PrincessPrefab;
    public int MaxPrincesses = 3;
    private int _curPrincesses;

    private int curPrincesses
    {
        get => _curPrincesses;
        set => _curPrincesses = Math.Max(value, 0);
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (!GameOver && curPrincesses < MaxPrincesses)
        {
            SpawnPrincess();
        }
    }

    private void SpawnPrincess()
    {
        var spawnPos = Points[new System.Random().Next(0, Points.Length)];

        var princess = Instantiate(PrincessPrefab, spawnPos, Quaternion.identity);

        // Set the variables for princess onclick
        Variables.Object(princess).Set("Camera", this.Camera);
        Variables.Object(princess).Set("GameState", this);

        curPrincesses++;
    }

    public void StartGame()
    {
        GameOver = false;
        Score = 0;
        StartCoroutine(CountdownCoroutine());
    }

    /// <summary>
    /// Princess was killed by clicking on it.
    /// </summary>
    public void PrincessKilled(int points)
    {
        curPrincesses--;
        if (!GameOver)
            Score += points;
    }

    /// <summary>
    /// Pricess moved out the visible view.
    /// </summary>
    public void PrincessHidden()
    {
        curPrincesses--;
    }

    private IEnumerator CountdownCoroutine()
    {
        remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            SetCountdownText(remainingTime);
            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
        }

        SetCountdownText(0f);

        handleGameOver();
    }

    private void handleGameOver()
    {
        Debug.Log("Game over");
        GameOver = true;
    }

    private void SetCountdownText(float remainingSec)
    {
        CountdownText.text = "Time: " + Mathf.CeilToInt(remainingSec);
    }

}
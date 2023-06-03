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

    private bool _isGameOver = false;

    public bool IsGameOver
    {
        get => _isGameOver;
        private set
        {
            _isGameOver = value;
            GameOverUI.SetActive(value);
        }
    }

    public float countdownTime = 30f;
    private float remainingTime;

    public Vector3[] Points;

    public GameObject PrincessPrefab;
    public int MaxPrincesses = 3;

    public GameObject DragonPrefab;
    public int MaxDragons = 3;

    private int _curPrincesses;

    private int curPrincesses
    {
        get => _curPrincesses;
        set => _curPrincesses = Math.Max(value, 0);
    }

    private int _curDragons;

    private int curDragons
    {
        get => _curDragons;
        set => _curDragons = Math.Max(value, 0);
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (!IsGameOver)
        {
            if (curPrincesses < MaxPrincesses)
            {
                SpawnPrincess();
            }

            if( curDragons < MaxDragons)
            {
                SpawnDragon();
            }
        }
    }

    private void SpawnPrincess()
    {
        var spawnPos = Points[new System.Random().Next(0, Points.Length)];

        var princess = Instantiate(PrincessPrefab, spawnPos, Quaternion.identity);
        var princessScript = princess.GetComponent<PrincessScript>();

        princessScript.Camera = this.Camera;
        princessScript.GameStateScript = this;

        curPrincesses++;
    }

    private void SpawnDragon()
    {
        var spawnPos = Points[new System.Random().Next(0, Points.Length)];

        var dragon = Instantiate(DragonPrefab, spawnPos, Quaternion.identity);
        var dragonScript = dragon.GetComponent<DragonScript>();

        dragonScript.Camera = this.Camera;
        dragonScript.GameStateScript = this;

        curDragons++;
    }

    public void StartGame()
    {
        IsGameOver = false;
        Score = 0;
        StartCoroutine(CountdownCoroutine());
    }

    /// <summary>
    /// Princess was killed by clicking on it.
    /// </summary>
    public void PrincessKilled(int points)
    {
        curPrincesses--;
        if (!IsGameOver)
            Score += points;
    }

    /// <summary>
    /// Pricess moved out the visible view.
    /// </summary>
    public void PrincessHidden()
    {
        curPrincesses--;
    }

    public void DragonKilled(int points)
    {
        curDragons--;
        if (!IsGameOver)
            Score += points;
    }

    public void DragonHidden()
    {
        curDragons--;
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
        IsGameOver = true;
    }

    private void SetCountdownText(float remainingSec)
    {
        CountdownText.text = "Time: " + Mathf.CeilToInt(remainingSec);
    }
}
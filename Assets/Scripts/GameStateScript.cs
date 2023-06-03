using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{

    public int Score;
    public Camera Camera;
    public UIText UiText; 

    public Vector3[] Points;

    public GameObject PrincessPrefab;
    public int MaxPrincesses = 3;
    private int curPrincesses = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        UiText.GameState = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (curPrincesses < MaxPrincesses)
        {
            var spawnPos = Points[new System.Random().Next(0, Points.Length)];

            var princess = Instantiate(PrincessPrefab, spawnPos, Quaternion.identity);

            // Set the variables for onclick
            Variables.Object(princess).Set("Camera", this.Camera);
            Variables.Object(princess).Set("GameState", this);
            
            curPrincesses++;
        }
    }

    public void PrincessKilled()
    {
        curPrincesses--;
        Score++;
        UiText.UpdateScore();
    }

    public void PrincessHidden()
    {
        curPrincesses--;
    }
}

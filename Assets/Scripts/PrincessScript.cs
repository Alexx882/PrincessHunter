using Unity.VisualScripting;
using UnityEngine;

public class PrincessScript : SubjectBaseScript
{
    
    void Start()
    {
        randomlyInitDirection();
    }

    void Update()
    {
    }

    protected override void HandleSubjectClicked()
    {
        Debug.Log("princess hit");

        GameStateScript.PrincessKilled(points);
    }

    protected override void HandleSubjectHidden()
    {
        GameStateScript.PrincessHidden();
    }
    
}
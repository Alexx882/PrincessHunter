using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : SubjectBaseScript
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
        Debug.Log("dragon hit");
        
        GameStateScript.DragonKilled(points);
    }

    protected override void HandleSubjectHidden()
    {
        GameStateScript.DragonHidden();
    }
}

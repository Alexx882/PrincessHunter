using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessScript : WrapperNodeTarget
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this.GetComponent<Rigidbody2D>().velocity = Vector2.left;
    }

    void PrincessClicked()
    {
        Debug.Log("princess ");
    }

    public override void run()
    {
        PrincessClicked();
    }
}

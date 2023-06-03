using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrincessScript : WrapperNodeTarget
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 transformLocal;
        
        if (Random.value > .5)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right;
            transformLocal = transform.localScale;
            transform.localScale = new Vector3(-transformLocal.x, transformLocal.y, transformLocal.z);
        }
        transformLocal = transform.localScale;
        transform.localScale = new Vector3(transformLocal.x, transformLocal.y, transformLocal.z + Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        // this.GetComponent<Rigidbody2D>().velocity = Vector2.left;
    }

    void PrincessClicked()
    {
        Debug.Log("princess");
        
        var gameStateScript = Variables.Object(this).Get<GameStateScript>("GameState");
        gameStateScript.PrincessKilled();
        
        Destroy(this.gameObject);
    }

    public override void run()
    {
        PrincessClicked();
    }
}

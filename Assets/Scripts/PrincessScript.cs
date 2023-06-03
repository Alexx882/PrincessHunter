using Unity.VisualScripting;
using UnityEngine;

public class PrincessScript : WrapperNodeTarget
{
    // Start is called before the first frame update
    private bool dead = false;

    public int points = 10;

    public GameObject pointsInfoPrefab;

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
    }

    void PrincessClicked()
    {
        Debug.Log("princess hit");
        dead = true;

        var gameStateScript = Variables.Object(this).Get<GameStateScript>("GameState");
        gameStateScript.PrincessKilled(points);

        var pointsInfo = Instantiate(pointsInfoPrefab, transform.position, Quaternion.identity);
        // TODO decouple the game objects
        pointsInfo.GetComponent<PointsInfoScript>().Init(points, gameStateScript.GameOver);

        Destroy(this.gameObject);
    }

    /// <summary>
    /// Triggered from Script Graph, onClick.
    /// </summary>
    public override void run()
    {
        // PrincessClicked();
    }

    void OnBecameInvisible()
    {
        if (dead) return;

        Debug.Log("princess invis");

        var gameStateScript = Variables.Object(this).Get<GameStateScript>("GameState");
        gameStateScript.PrincessHidden();

        Destroy(this.gameObject);
    }


    public void OnMouseDown()
    {
        var cam = Variables.Object(this).Get<Camera>("Camera");

        Vector2 mousePos = new Vector2();
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        var point = cam.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));

        var hit = Physics2D.Raycast(point, new Vector2(0, 0));

        if (hit.rigidbody.gameObject == this.gameObject)
        {
            PrincessClicked();
        }
    }
}
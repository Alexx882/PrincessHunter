using Unity.VisualScripting;
using UnityEngine;


public abstract class SubjectBaseScript : MonoBehaviour
{
    protected bool dead = false;

    // set during instantiation
    public Camera Camera;
    public GameStateScript GameStateScript;
    
    public int points = 10;

    public GameObject pointsInfoPrefab;

    
    public  void randomlyInitDirection()
    {
        Vector3 transformLocal;

        if (Random.value > .5)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right;
            // mirror animation
            transformLocal = transform.localScale;
            transform.localScale = new Vector3(-transformLocal.x, transformLocal.y, transformLocal.z);
        }

        // transformLocal = transform.localScale;
        // transform.localScale = new Vector3(transformLocal.x, transformLocal.y, transformLocal.z + Random.value);
    }
    
    /// <summary>
    /// Automatically despawn the subjects outside the view.
    /// </summary>
    void OnBecameInvisible()
    {
        if (dead) return;

        HandleSubjectHidden();

        Destroy(this.gameObject);
    }

    public void OnMouseDown()
    {
        Vector2 mousePos = new Vector2();
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        var point = Camera.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));

        var hit = Physics2D.Raycast(point, new Vector2(0, 0));

        if (hit.rigidbody.gameObject == this.gameObject)
        {
            dead = true;
            
            HandleSubjectClicked();
            
            var pointsInfo = Instantiate(pointsInfoPrefab, transform.position, Quaternion.identity);
            // TODO decouple the game objects
            pointsInfo.GetComponent<PointsInfoScript>().Init(points, GameStateScript.IsGameOver);

            Destroy(this.gameObject);
        }
    }

    protected abstract void HandleSubjectClicked();

    protected abstract void HandleSubjectHidden();
}
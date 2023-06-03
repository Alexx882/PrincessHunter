using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsInfoScript : MonoBehaviour
{
    private TextMeshPro pointsText;

    // Start is called before the first frame update
    void Start()
    {
        // var transformLocal = transform.localScale;
        // transform.localScale = new Vector3(transformLocal.x, transformLocal.y, transformLocal.z-10);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Shows the points and plays death sound
    /// </summary>
    /// <param name="points"></param>
    public void Init(int points, bool gameOver)
    {
        if (!gameOver)
        {
            pointsText = GetComponent<TextMeshPro>();
            pointsText.text = "+" + points;
        }

        float clipDuration = GetComponent<PlayDeathSoundScript>().PlaySound();
        // wait for sound to finish
        StartCoroutine(DestroyAfterSound(clipDuration));
    }

    IEnumerator DestroyAfterSound(float clipDuration)
    {
        yield return new WaitForSeconds(clipDuration);
        Destroy(this.gameObject);
    }
}
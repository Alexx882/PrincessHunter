using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScreenButtonScript : MonoBehaviour
{
    public string sceneToLoad;
    public AudioClip clip;

    private Button _button;
    private AudioSource audioSource;
    
    void Start()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (clip != null)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            StartCoroutine(LoadSceneDelay(clip.length));
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private IEnumerator LoadSceneDelay(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    void Update()
    {
        
    }
}

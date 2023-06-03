using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScreenButtonScript : MonoBehaviour
{
    public string sceneToLoad;

    private Button _button;
    
    void Start()
    {
        _button = GetComponent<Button>();
        // _button.text = "Start Game";
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        
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

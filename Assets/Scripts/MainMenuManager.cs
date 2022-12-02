using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //Cached References
    
    [SerializeField] private Button _btnNewGame;
    [SerializeField] private Button _btnQuitGame;
    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _btnQuitGame.onClick.AddListener(QuitGame);
        _btnNewGame.onClick.AddListener(NewGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

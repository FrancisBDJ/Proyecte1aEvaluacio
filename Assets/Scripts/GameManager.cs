using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    private int _playerLives = 3;
    
    [SerializeField]
    private int _score = 0;
    public int level; 
    
    //Cached References
    public GameObject plane;
    public GameObject start;
    public GameObject goal;
    [SerializeField] 
    private TextMeshProUGUI _txtGameOver;
    [SerializeField]
    private TextMeshProUGUI _txtWinMasage;

    [SerializeField] 
    private Button _nextLevelButton;
    [SerializeField] 
    private Button _playAgainButton;
    [SerializeField] 
    private Button _quitGameButton;
    


    private void InitLevel1()
    {
        

        plane.transform.position = start.transform.position;

    }
    
    private void InitLevel2()
    {
        

        plane.transform.position = start.transform.position;

    }

    public void LoseLife()
    {
        
        _playerLives = _playerLives - 1;
        if (level == 1)
        {
            InitLevel1();
        }
        
        if (level == 2)
        {
            InitLevel2();
        }

        if (_playerLives < 1)
        {
            GameOver();
        }
    }

    public void WinLevel()
    {
        
        
        _txtWinMasage.gameObject.SetActive(true);
        _nextLevelButton.gameObject.SetActive(true);
        _playAgainButton.gameObject.SetActive(true);
        _quitGameButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        level++;

    }


    public void GameOver()
    {
        if (level == 1)
        {
            _txtGameOver.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        _txtGameOver.gameObject.SetActive(false);
        _txtWinMasage.gameObject.SetActive(false);
        _playAgainButton.gameObject.SetActive(false);
        _quitGameButton.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
        
        
        if (level == 1)
        {
            InitLevel1();
        }
        
        if (level == 2)
        {
            InitLevel2();
        }

       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plane.transform.position.z >= goal.transform.position.z)
        {
            WinLevel();
        }
    }
}

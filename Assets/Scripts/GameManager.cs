using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    private int _playerLives;
    
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
        
        
        if (_playerLives == 0)
        {
            _playerLives =  3;
            
        }

        plane.transform.position = start.transform.position;
        _txtGameOver.gameObject.SetActive(false);
        _txtWinMasage.gameObject.SetActive(false);
        _playAgainButton.gameObject.SetActive(false);
        _playAgainButton.onClick.AddListener(ReplayLevel);
        _quitGameButton.gameObject.SetActive(false);
        _quitGameButton.onClick.AddListener(QuitGame);
        _nextLevelButton.gameObject.SetActive(false);
        _nextLevelButton.onClick.AddListener(PlayNextLevel);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void InitLevel2()
    {
        plane.transform.position = start.transform.position;
        _txtGameOver.gameObject.SetActive(false);
        _txtWinMasage.gameObject.SetActive(false);
        _playAgainButton.gameObject.SetActive(false);
        _playAgainButton.onClick.AddListener(ReplayLevel);
        _quitGameButton.gameObject.SetActive(false);
        _quitGameButton.onClick.AddListener(QuitGame);
        _nextLevelButton.gameObject.SetActive(false);
        _nextLevelButton.onClick.AddListener(PlayNextLevel);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        if (_playerLives == 0)
        {
            _playerLives = 3;
            
        }
        
    }

    public void LoseLife()
    {
        
        _playerLives = _playerLives - 1;
        if (_playerLives == 0)
        {
            GameOver();
        }
        else
        {
            if (level == 1)
            {
                InitLevel1();
            }
        
            if (level == 2)
            {
                InitLevel2();
            }
        }
       
    }

    public void WinLevel()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        _txtWinMasage.gameObject.SetActive(true);
        if (level == 1)
        {
            _nextLevelButton.gameObject.SetActive(true);
            _playAgainButton.gameObject.SetActive(true);
            _quitGameButton.gameObject.SetActive(true);
            
        }

        if (level == 2)
        {
            
            _playAgainButton.gameObject.SetActive(true);
            _quitGameButton.gameObject.SetActive(true);
        }
        

    }


    public void GameOver()
    {
        _txtGameOver.gameObject.SetActive(true);
        _playAgainButton.gameObject.SetActive(true);
        _quitGameButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
    
    private void ReplayLevel()
    {
        if (level == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        if (level == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        
    }

    private void PlayNextLevel()
    {
        _score = _score + 100;
        level++; 
        SceneManager.LoadScene("Level2");
    }
    
    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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
        plane = GameObject.FindGameObjectWithTag("Player");
        _txtGameOver.gameObject.SetActive(false);
        _txtWinMasage.gameObject.SetActive(false);
        _playAgainButton.gameObject.SetActive(false);
        _playAgainButton.onClick.AddListener(ReplayLevel);
        _quitGameButton.gameObject.SetActive(false);
        _quitGameButton.onClick.AddListener(QuitGame);
        _nextLevelButton.gameObject.SetActive(false);
        _nextLevelButton.onClick.AddListener(PlayNextLevel);
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

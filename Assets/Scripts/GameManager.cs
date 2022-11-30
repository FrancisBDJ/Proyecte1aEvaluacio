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
    public int _level = 1;
    [SerializeField]
    private bool _win = false;
    [SerializeField]
    private int _score;
    
    
    //Cached References
    public GameObject plane;
    public GameObject start;
    public GameObject goal;

    [SerializeField] 
    private TextMeshProUGUI _txtGameOver;
    [SerializeField]
    private TextMeshProUGUI _txtWinMasage;
    
    



    private void InitLevel1()
    {
        _txtGameOver.gameObject.SetActive(false);
        _win = false;
        _txtWinMasage.gameObject.SetActive(false);

        plane.transform.position = start.transform.position;

    }
    
    private void InitLevel2()
    {
        _txtGameOver.gameObject.SetActive(false);
        _win = false;
        _txtWinMasage.gameObject.SetActive(false);

        plane.transform.position = start.transform.position;

    }

    public void LoseLife()
    {
        
        _playerLives = _playerLives - 1;
        if (_level == 1)
        {
            InitLevel1();
        }
        
        if (_level == 2)
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
        _win = true;
        _level++;
        _txtWinMasage.gameObject.SetActive(true);
        Time.timeScale = 0f;
        
    }


    public void GameOver()
    {
        if (_level == 1)
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
        
        if (_level == 1)
        {
            InitLevel1();
        }
        
        if (_level == 2)
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

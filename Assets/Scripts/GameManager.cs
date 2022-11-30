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
    private int _level = 1;
    [SerializeField]
    private bool _win = false;
    [SerializeField]
    private int _score;
    
    
    //Cached References
    public GameObject plane;
    public GameObject start;

    [SerializeField] private TextMeshProUGUI _txtGameOver;
    
    



    private void InitLevel1()
    {
        _txtGameOver.gameObject.SetActive(false);
        _win = false;

        plane.transform.position = start.transform.position;

    }

    public void LoseLife()
    {
        
        _playerLives = _playerLives - 1;
        if (_level == 1)
        {
            InitLevel1();
        }

        if (_playerLives < 1)
        {
            GameOver();
        }
        
        
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

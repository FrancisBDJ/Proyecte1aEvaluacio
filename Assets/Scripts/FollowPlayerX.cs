using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    
    private GameManager _gameManager;
    public GameObject plane;
    private Vector3 offsetLevel1 = new Vector3(85,0,30);
    private Vector3 offsetLevel2 = new Vector3(2,0,-12);
    

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager._level == 1)
        {
            if (plane != null)
            {
            

                transform.position = plane.transform.position + offsetLevel1;
            }
        }
        if (_gameManager._level == 2)
        {
            if (plane != null)
            {
            

                transform.position = plane.transform.position + offsetLevel2;
                
            }
        }
    }
}

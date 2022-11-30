using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private GameManager _gameManager;
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W) == true)
        {
            // Move up
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Move backwards
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed );

        // Rotation 
        transform.Rotate( -verticalInput * rotationSpeed * Time.deltaTime,0, 0);
        transform.Rotate( 0,0, -horizontalInput * rotationSpeed * Time.deltaTime);
        // tilt the plane up/down based on up/down arrow keys
    }
}

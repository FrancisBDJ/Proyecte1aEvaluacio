using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        
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
        
        // tilt the plane up/down based on up/down arrow keys
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class cloudScript : MonoBehaviour
{
    // This is the speed at which the cloud is moving
    public float speed = 10.5f;
    // The direction of the cloud
    public Vector3 direction;
    // The amount of time that must pass between resets
    public float resetTime = 10f;

    //Start position of the clouds
    private Vector3 startingPos;
    // Keeps track of how much time has passed since cloud left original position
    private float timePassed = 0;
    // Keeps track of the direction of the clouds
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // The position of the cloud at the start of the game is cache'd
        startingPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            Movement(Vector3.right);
        }
        else if (!movingRight)
        {
            Movement(Vector3.left);
            //Movement(-Vector3.right);
        }

        // Time is added to time passed counter
        timePassed += Time.deltaTime;
        /*
        // If timePassed since last reset is more or equal than the time between resets...
        if (timePassed >= resetTime)
        {
            // Set the position of the object to its starting position
            this.gameObject.transform.position = startingPos;
            // Set the timne passed to 0
            timePassed = 0;
        }
        */
        if (timePassed >= resetTime)
        {
            // Invert the direction
            movingRight = !movingRight;
            // Set the timne passed to 0
            timePassed = 0;
        }
    }

    private void Movement(Vector3 direction)
    {
        /*
        //// Method A
        //// Method A doesn't work inside this function
        //Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
        //this.gameObject.transform.position.x = this.gameObject.transform.position + movement;
         
        //// Method B
        //Vector3 movement = direction * speed * Time.deltaTime;
        //this.gameObject.transform.position += movement;

        //// Method C
        //Vector3 movement = this.gameObject.transform.position + (direction * speed * Time.deltaTime);
        //this.gameObject.transform.position = movement;

        */
        // Method D
        Vector3 finalPosition = this.gameObject.transform.position;
        // If you want to change direction object is going 
        //finalPosition += direction * speed * Time.deltaTime;
        finalPosition += direction * speed * Time.deltaTime;
        this.gameObject.transform.position = finalPosition;
    }
}

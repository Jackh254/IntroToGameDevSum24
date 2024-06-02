using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour
{
    // PUBLIC VARIABLES ----------------
    // Counter to keep track of when to change directions
    public float timeCounter = 5.0f;
    // Counter to trigger timeCounter
    private float trueCounter = 1.0f;
    // This is the speed at which the cloud is moving
    public float speed = 10.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Adding to the counter
        trueCounter += Time.deltaTime;

        /*
        * THIS IS AN EXAMPLE OF HARD CODED SCRIPT
        // If timer less than or equal to 20 move right
        if (timeCounter <= 20)
        {
            Movement(Vector3.right); 
        }
        // If timer less than or equal to 40 and greater than 20 move up
        else if (timeCounter <= 40 && timeCounter > 20)
        {
            Movement(Vector3.up);
        }
        // If timer less than or equal to 60 and greater than 40 move left
        else if (timeCounter <= 60 && timeCounter > 40)
        {
            Movement(Vector3.left);
        }
        // If timer less than or equal to 80 and greater than 60 move down
        else if (timeCounter <= 80 && timeCounter > 60)
        {
            Movement(Vector3.down);
        }
        // Reset the timer to continue the infinite movement
        else
        {
            timeCounter = 0;
        }
        */

        // If timer less than or equal to timeCounter * 2 move right
        if (trueCounter <= (timeCounter * 2))
        {
            Movement(Vector3.right);
        }
        // If timer less than or equal to 4 * timeCounter and greater than 2 * timeCounter move up
        else if (trueCounter <= (timeCounter * 4) && (trueCounter > (timeCounter * 2)))
        {
            Movement(Vector3.up);
        }
        // If timer less than or equal to 6 * timeCounter and greater than 4 * timeCounter move left
        else if (trueCounter <= (timeCounter * 6) && (trueCounter > (timeCounter * 4)))
        {
            Movement(Vector3.left);
        }
        // If timer less than or equal to 8 * timeCounter and greater than 6 * timeCounter move down
        else if (trueCounter <= (timeCounter * 8) && (trueCounter > (timeCounter * 6)))
        {
            Movement(Vector3.down);
        }
        // Reset the timer to continue the infinite movement
        else
        {
            trueCounter = 0;
        }
    }

    // Function to make the object move
    void Movement(Vector3 direction)
    {
        Vector3 movingObject = this.gameObject.transform.position;
        movingObject += direction * speed * Time.deltaTime;
        this.gameObject.transform.position = movingObject;
    }
}

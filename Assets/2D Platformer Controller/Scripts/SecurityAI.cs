using UnityEngine;
using System.Collections;

public class SecurityAI : MonoBehaviour
{

    //public Rigidbody2D instanceRigidbody;
    public Animator anim;
    float movementSpeed = 3f;

    short moveDirection = 0;
    int aiCounter = 0;

    // Use this for initialization
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var isMoving = false;
        aiCounter++;
        if (aiCounter > 250)
        {
            aiCounter = 0;
            // if idling
            if (moveDirection == 0)
            {
                // flip direction
                if (transform.eulerAngles.y == 0)
                    moveDirection = -1;
                else
                    moveDirection = 1;
            }
            else
            {
                // set to idle
                moveDirection = 0;
            }
        }

        // move left
        if (moveDirection == -1)
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
            isMoving = true;
        }
        // move right
        else if (moveDirection == 1)
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
            isMoving = true;
        }

        anim.SetBool("isWalking", isMoving);
    }
}

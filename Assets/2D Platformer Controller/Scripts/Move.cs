using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public Animator anim;

    float movementSpeed = 3f;
    float jumpSpeed = 250;
    bool isGrounded = false;
    bool isSneak = false;

    // Use this for initialization
    void Start() {

    }
 
    void Update() {
        var isMoving = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSneak = !isSneak;
            if (isSneak)
            {
                movementSpeed = 1.5f;
                jumpSpeed = 125;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            }
            else
            {
                movementSpeed = 3f;
                jumpSpeed = 250;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0,180,0);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
            isMoving = true;
        }
        /*if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!isGrounded)
            {
                rigidbody2D.gravityScale += 2;
            }
        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                var force = playerRigidbody.velocity.y + jumpSpeed;
                if (force > jumpSpeed * 1.1f)
                {
                    force = jumpSpeed * 1.1f - playerRigidbody.velocity.y;
                }
                playerRigidbody.AddForce(Vector3.up * force); // jumpSpeed
                
                isGrounded = false;
            }
        }

        /*if (isGrounded && isMoving)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }*/

        anim.SetBool("isWalking", isGrounded && isMoving);
        anim.SetBool("isSneak", isSneak);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (ContactPoint2D contactPoint in col.contacts)
        {
            if (contactPoint.point.y < playerRigidbody.position.y)
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }
}
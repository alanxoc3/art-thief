using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Rigidbody2D rigidbody2D;
    public float movementSpeed = 3f;
    public float jumpSpeed = 500f;
    public bool isGrounded = true;
    public Animator anim;

    // Use this for initialization
    void Start() {

    }
 
    void Update() {
        /*if (isGrounded)
        {
            rigidbody2D.gravityScale = 2.1f;
        }*/
        var isMoving = false;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0,180,0);
            isMoving = true;
            //isGrounded = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
            isMoving = true;
            //isGrounded = false;
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
                var force = rigidbody2D.velocity.y + jumpSpeed;
                if (force > jumpSpeed * 1.1f)
                {
                    force = jumpSpeed * 1.1f - rigidbody2D.velocity.y;
                }
                rigidbody2D.AddForce(Vector3.up * force); // jumpSpeed
                
                isGrounded = false;
            }
        }

        if (isGrounded && isMoving)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (ContactPoint2D contactPoint in col.contacts)
        {
            if (contactPoint.point.y < rigidbody2D.position.y)
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //speed we want the character to move
    public float speed = 1;

    //how powerful character can jump
    public float jumpForce = 1;

    //distance to check from character to the ground
    public float groundCheckDistance = 0.5f;

    //the sprite
    SpriteRenderer sprite = null;

    Rigidbody2D rb = null;

    //check if the character is in the air
    bool inAir = false;

    //direction
    float scaleX = 1;




    // Start is called before the first frame update
    void Start()
    {

        //set base vars
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //set the speed for left and right but don't mess with up and down
        rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed + Vector2.up * rb.velocity.y;


        //flip the sprite to set the direction
        if (Input.GetAxis("Horizontal") != 0) {
            int direction = 1;
            if (Input.GetAxis("Horizontal") < 0) {
                direction = -1;
            }
            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);

        }

        //make sure character is on the ground by checking the distance from character downwards
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);

        //if there is ground close enough you aren't in the air
        inAir = hit.collider == null; 


        //if the character is on the ground and "jump space bar is pushed character jumps
        if(!inAir && Input.GetButtonDown("Jump")) {
            transform.position += Vector3.up * 0.1f;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}

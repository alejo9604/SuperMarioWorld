using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float velX = 0.1f;
    float movX;
    //public float inputX;

    //public float jumpForce = 100f;

    //Better Jump
    [Range(1,10)]
    public float jumpForce;
    public float fallMultipler = 2.5f;
    public float lowJumpMultipler = 2f;

    Rigidbody2D rb;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxis("Horizontal");

        if( inputX > 0 )
        {
            movX = transform.position.x + (inputX * velX * Time.deltaTime);
            transform.position = new Vector3(movX, transform.position.y, 0);
            transform.localScale = new Vector3(1, 1, 1);    

        }else if( inputX < 0)
        {
            movX = transform.position.x + (inputX * velX * Time.deltaTime);
            transform.position = new Vector3(movX, transform.position.y, 0);
            transform.localScale = new Vector3(-1, 1, 1);

        }


        
        if( Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce( new Vector2(0, jumpForce));
            rb.velocity = Vector2.up * jumpForce;
        }
        


        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipler - 1) * Time.deltaTime;
         

        }else if ( rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;

        }
        
        		
	}
}

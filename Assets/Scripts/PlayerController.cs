using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rigidbody2d;
    private BoxCollider2D collider;

    private bool isGrounded;
    private bool facingRight;

    private SpriteRenderer spriteRenderer;

    private float h;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        if (h < 0)
        {
            facingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            facingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = new Vector2(h * speed, rigidbody2d.velocity.y);


    }

    void Inputs()
    {
        if (Input.GetKey(KeyCode.D)) h = 1;
        else if (Input.GetKey(KeyCode.A)) h = -1;
        else h = 0;
        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            rigidbody2d.AddForce(Vector2.up * jumpForce);
        }
    }
}

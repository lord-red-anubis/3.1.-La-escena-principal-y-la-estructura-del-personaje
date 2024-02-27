using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class johnbour : MonoBehaviour
{
    public float jumpforce;
    public float speed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float horizontal;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("horizontal");

        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded= true;
        }
        else grounded= false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump();
        }
    }

    private void jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpforce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonSystem : MonoBehaviour
{
    private float _horizontal;
    private Rigidbody2D _rigidbody2D;
    private bool _onGround;
    public float jumpForce;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        _horizontal = Input.GetAxisRaw("Horizontal");
         
        Debug.DrawRay(transform.position,Vector3.down * 0.1f, Color.red);
        _onGround = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);

        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            Jump();
        }
    }
    //declaring
    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontal, _rigidbody2D.velocity.y);
    }
}

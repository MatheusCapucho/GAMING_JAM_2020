using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour

{   
    public Rigidbody2D rb;
    public Camera cam;
    private SpriteRenderer sr;

    private Vector2 movementInput;
    public float speed;


   
    private void Awake()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();   
    }

    void Update()
    {       
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if (movementInput == Vector2.zero)
        {
            // idle
        }
        else if (movementInput.x > 0)
        {
            // animacao pro lado
            sr.flipX = true;
        }
        else if (movementInput.x < 0)
        {
            // animacao pro lado
            sr.flipX = false;
        }
        else if (movementInput.y > 0)
        {
            // animacao pra cima

        }
        else if (movementInput.y < 0)
        {
            // animacao pra baixo
        }
    }
    private void FixedUpdate() {

        rb.velocity = movementInput * speed;
     
    }
}

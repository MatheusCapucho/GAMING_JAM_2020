using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour

{   
    public Rigidbody2D rb;
    public Camera cam;
    
    private  Vector2 movementInput;
    private Vector2 mousePosition;
    private float speed = 10f;
   
    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();   
    }

    void Update()
    {       
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

    }
    private void FixedUpdate() {

        Vector2 lookAtMouse = mousePosition - rb.position;

        rb.velocity = movementInput * speed;
    }
}

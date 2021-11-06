using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 playerInput = new Vector2();
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        playerInput.x = inputX;
        playerInput.y = inputY;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerInput * speed);
    } 
}

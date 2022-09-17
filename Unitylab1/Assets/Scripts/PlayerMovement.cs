using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    CircleCollider2D circleCollider;
    Rigidbody2D rbody;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInput * movementSpeed * 100 * Time.deltaTime, rbody.velocity.y);   
        Debug.Log(Time.deltaTime);
        rbody.velocity = movementVector;
    }

    void Update()
    {
        
    if(!circleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
          return;
        }
    if (Input.GetButtonDown("Jump"))
        {
           rbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
}

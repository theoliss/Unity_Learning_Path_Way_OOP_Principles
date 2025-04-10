using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float player_speed;
    [SerializeField] private float player_rotation_speed;
    private float X_boundary;
    private float Z_boundary;
    [SerializeField] private float jumpForce;
    private Rigidbody playerRB;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ground =  GameObject.Find("Ground");
        BoxCollider groundSpecs = ground.GetComponent<BoxCollider>();
        float groundScaleX =  ground.transform.localScale.x;
        float groundScaleZ =  ground.transform.localScale.z;
        X_boundary = groundSpecs.size.x/2 * groundScaleX;  
        Z_boundary = groundSpecs.size.z/2 * groundScaleZ;

        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ABSTRACTION
        Move();
        Rotate();
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            canJump = false;
        }   
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    private void Move()
    {
        Vector3 startingPosition = transform.position;
        Vector3 horizontalMovingDistance = Vector3.right * player_speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 verticalMovingDistance = Vector3.forward * player_speed * Time.deltaTime * Input.GetAxis("Vertical");;
        transform.Translate(verticalMovingDistance + horizontalMovingDistance);
        if(transform.position.x > X_boundary ||transform.position.x < -X_boundary || transform.position.z > Z_boundary || transform.position.z < -Z_boundary)
        {
            transform.position = startingPosition;
        }

    }

    private void Rotate()
    {
      transform.Rotate(new Vector3( 0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * player_rotation_speed);
    }

    private void Jump()
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, 0, playerRB.velocity.z);
        playerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
    }

}

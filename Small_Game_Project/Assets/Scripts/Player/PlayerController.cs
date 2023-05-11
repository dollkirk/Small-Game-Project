using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerObj;
    Rigidbody rb;

    [Header("Player Movement")]
    float h;
    float v;
    public float moveSpeed;
    public float rotationSpeed;


    [Header("Player Jump")]
    public float jumpForce;
    public float airMultiplier;
    private const int maximumJumps = 1;
    private int currentJump = 0;


    [Header("Player Grounded")]
    public float checkGroundDistance = 0.51f;
    public LayerMask Ground;
    bool grounded;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }




    void Update()
    {
        //Checking if the player is on ground by using raycast
        grounded = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y * 0.5f + checkGroundDistance, Ground);
        //Debug.Log(grounded);

        if (grounded)
        {
            currentJump = 0;
        }

        MyInput();

        //Debug.Log(currentJump);


        //Rotating the player in the direction of movement
        Vector3 direction = new Vector3(h, 0.0f, v);
        // magnitude is the length of the vector
        if (direction.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed);
        }
        
    }




    private void FixedUpdate()
    {
        MovePlayer();
    }




    void MyInput()
    {
        //Checking for arrow key movement
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


        //Checking for jump key input
        if (Input.GetKeyDown(KeyCode.Space) && (grounded || maximumJumps > currentJump))
        {
            Jump();
            currentJump++;
        }
    }




    void MovePlayer()
    {
        if (grounded)
        {
            rb.AddForce(h * moveSpeed, 0, v * moveSpeed, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(h * moveSpeed * airMultiplier, 0, v * moveSpeed * airMultiplier, ForceMode.Force);
        }
    }

    //A function that is called when jump key is pressed. This will apply a force upwards to the player.
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<AIStateController>(out AIStateController aIState))
        {
            if (aIState.currentState == aIState.enemyState)
            {
                if (gameObject.TryGetComponent<HealthSystem>(out HealthSystem health))
                {
                    health.TakeDamage(1);
                }
            }
        }
    }
}

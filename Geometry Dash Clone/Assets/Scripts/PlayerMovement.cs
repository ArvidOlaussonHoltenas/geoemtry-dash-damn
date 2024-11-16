using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ContactFilter2D groundFilter;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float shipPower = 1f;
    [SerializeField] float gravityScale = 5f;
    [SerializeField] float floorHeight = 0.5f;
    [SerializeField] Transform feet;
    [SerializeField] ContactFilter2D filter;
    public bool isGrounded;
    public bool jumpInput;
    public bool jumpInputPressed;
    public string gamemode;
    public float velocityX;
    public float velocityY;
    public int flipGravity = 1; //1 = false, -1 = true
    Collider2D[] results = new Collider2D[1];

    void Start()
    {
        gamemode = "cube";
    }

    private void Update()
    {
        Movement();
        CheckGround();
        if (Physics2D.OverlapBox(feet.position, feet.localScale, 0, filter, results) > 0 && velocityY <= 0)
        {
            velocityY = 0;
            Vector2 surface = Physics2D.ClosestPoint(transform.position, results[0]) + Vector2.up * floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        CheckInput();
        ChangeGamemode();

        switch (gamemode)
        {
            case "cube":
                CubePhysics();
                break;
            case "ship":
                ShipPhysics();
                break;
            case "ufo":
                UfoPhysics();
                break;
            case "wave":
                WavePhysics();
                break;
        }

        transform.Translate(new Vector3(velocityX, velocityY, 0) * Time.deltaTime); //Apply movement
    }
    
    void CheckGround()
    {
        /*if (Physics2D.OverlapBox(feet.position, feet.localScale, 0, filter, results) > 0 && velocityY <= 0)
        {
            velocityY = 0;
            Vector2 surface = Physics2D.ClosestPoint(transform.position, results[0]) + Vector2.up * floorHeight;
            transform.position = new Vector3(transform.position.x, surface.y, transform.position.z);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }*/
    }

    void Movement()
    {
        velocityX = moveSpeed; //Move forward
        velocityY += Physics2D.gravity.y * gravityScale * Time.deltaTime * flipGravity; //Gravity

        //Limit vertical velocity
        if (velocityY > 20)
        {
            velocityY = 20;
        }
        if (velocityY < -20)
        {
            velocityY = -20;
        }
    }

    void CheckInput()
    {
        jumpInputPressed = false;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            jumpInput = true;
            jumpInputPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            jumpInput = false;
        }
    }

    void CubePhysics()
    {
        gravityScale = 7;
        if (isGrounded)
        {
            if (jumpInput)
            {
                velocityY = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
            }
        }
    }

    void ShipPhysics()
    {
        //Limit vertical velocity
        if (velocityY > 10)
        {
            velocityY = 10;
        }
        if (velocityY < -10)
        {
            velocityY = -10;
        }
        gravityScale = 3;
        if (jumpInput)
        {
            velocityY += shipPower * Time.deltaTime * flipGravity;
        }
    }

    void UfoPhysics()
    {
        gravityScale = 6;
        if (jumpInputPressed)
        {
            if (flipGravity == -1)
            {
                velocityY = Mathf.Sqrt((jumpHeight - 0.5f) * -2 * (Physics2D.gravity.y * gravityScale)) * -1;
            }
            else
            {
                velocityY = Mathf.Sqrt((jumpHeight - 0.5f) * -2 * (Physics2D.gravity.y * gravityScale));
            }
        }
    }

    void WavePhysics()
    {
        gravityScale = 0;
        if (jumpInput)
        {
            velocityY = velocityX * flipGravity;

            if (flipGravity == -1 && isGrounded)
            {
                velocityY = 0;
            }
        }
        else
        {
            velocityY = -velocityX * flipGravity;

            if (isGrounded)
            {
                velocityY = 0;
                if (flipGravity == -1)
                {
                    velocityY = velocityX;
                }
            }
        }
    }

    void ChangeGamemode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gamemode = "cube";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gamemode = "ship";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gamemode = "ufo";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gamemode = "wave";
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            flipGravity = -flipGravity; //Flip gravity!
        }
    }
}

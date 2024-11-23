using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] CameraManager cameraManager;

    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float shipPower = 1f;
    public string gamemode;
    public int flipGravity = 1;
    public Rigidbody2D rb;
    public bool roof;
    public float castDistance;
    public Vector2 boxSize;
    public LayerMask groundLayer;
    bool jumpInput;
    bool jumpInputPressed;

    void Start()
    {
        gamemode = "cube";
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
        ChangeGamemode();

        CheckInput();

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
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
    void Movement()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        //Limit vertical velocity
        if (rb.velocity.y > 20)
        {
            rb.velocity = new Vector2(rb.velocity.x, 20);
        }
        if (rb.velocity.y < -20)
        {
            rb.velocity = new Vector2(rb.velocity.x, -20);
        }
    }

    void CheckInput()
    {
        jumpInputPressed = false;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpInput = true;
            jumpInputPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpInput = false;
        }
    }

    void CubePhysics()
    {
        rb.gravityScale = 7 * flipGravity;
        if (isGrounded() && jumpInput)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(-2.0f * Physics2D.gravity.y * jumpHeight * rb.gravityScale));
        }
    }

    void ShipPhysics()
    {
        rb.gravityScale = 3 * flipGravity;

        //Limit vertical velocity
        if (rb.velocity.y > 10)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        if (rb.velocity.y < -10)
        {
            rb.velocity = new Vector2(rb.velocity.x, -10f);
        }

        if (jumpInput)
        {
            rb.velocity += new Vector2(0f, shipPower * Time.deltaTime * flipGravity);
        }
    }

    void UfoPhysics()
    {
        rb.gravityScale = 6 * flipGravity;
        if (jumpInputPressed)
        {
            rb.velocity = new Vector2(rb.velocity.x, flipGravity * Mathf.Sqrt((jumpHeight - 0.5f) * -2 * (Physics2D.gravity.y * Mathf.Abs(rb.gravityScale))));
        }
    }

    void WavePhysics()
    {
        rb.gravityScale = 0;
        if (jumpInput)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.x * flipGravity);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.x * flipGravity);
        }
    }

    void ChangeGamemode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gamemode = "cube";
            Roof(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gamemode = "ship";
            Roof(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gamemode = "ufo";
            Roof(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gamemode = "wave";
            Roof(true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            flipGravity = -flipGravity; //Flip gravity!
        }
    }

    void Roof(bool enableRoof)
    {
        if (enableRoof)
        {
            roof = true;
            CameraManager.SwitchCamera(cameraManager.roofCam);
        }
        else
        {
            roof = false;
            CameraManager.SwitchCamera(cameraManager.normalCam);
        }
    }
}

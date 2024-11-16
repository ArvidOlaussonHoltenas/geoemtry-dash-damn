using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRotation : MonoBehaviour
{
    public GameObject playerExtra;
    public PlayerMovement playerMovement;

    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerMovement.gamemode == "cube")
        {
            spriteRenderer.sprite = sprites[0];
            playerExtra.SetActive(false);
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.localPosition = new Vector3(0f, 0f, -0.25f);
            float targetAngle = Mathf.Ceil(transform.rotation.z / 90) * 90;
            if (!playerMovement.isGrounded)
            {
                transform.Rotate(0f, 0f, -560f * Time.deltaTime);
            }
            else
            {
                var vec = transform.eulerAngles;
                vec.z = Mathf.Round(vec.z / 90) * 90;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(vec), 20f * Time.deltaTime);
            }
        }
        if (playerMovement.gamemode == "ship")
        {
            spriteRenderer.sprite = sprites[1];
            playerExtra.SetActive(true);
            transform.localScale = new Vector3(1.2f, 1.2f * playerMovement.flipGravity, 1f);
            transform.localPosition = new Vector3(0f, -0.2f * playerMovement.flipGravity, -0.5f);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, playerMovement.velocityY * 3.5f), 10f * Time.deltaTime);

            if (playerMovement.isGrounded)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 20f * Time.deltaTime);
            }
        }
    }

    public int SnapRotation(int rotation)
    {
        int remainder = rotation % 360;

        int snappedRotation = (int)(Math.Round((double)remainder / 90) * 90);

        if (snappedRotation < -270)
        {
            snappedRotation += 360;
        }

        return snappedRotation;
    }
}

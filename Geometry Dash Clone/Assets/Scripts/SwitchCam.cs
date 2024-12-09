using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.Build.Content;
using UnityEngine.InputSystem.LowLevel;

public class SwitchCam : MonoBehaviour
{
    [SerializeField] CameraManager cameraManager;
    [SerializeField] Player player;
    [SerializeField] GameObject groundRoof;
    [SerializeField] FixGroundRoof fixGroundRoof;

    void Update()
    {
        if (player.roof)
        {
            groundRoof.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            groundRoof.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

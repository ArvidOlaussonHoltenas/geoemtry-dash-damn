using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem.LowLevel;

public class SwitchCam : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject groundRoof;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject roofCamFollow;
    void Update()
    {
        if (player.roof)
        {
            groundRoof.GetComponent<BoxCollider2D>().enabled = true;
            cameraManager.roofCam.m_Follow = roofCamFollow.transform;
            cameraManager.normalCam.transform.position = new Vector3(cameraManager.normalCam.transform.position.x, cameraManager.roofCam.transform.position.y, cameraManager.normalCam.transform.position.z);
        }
        else
        {
            groundRoof.GetComponent<BoxCollider2D>().enabled = false;
            cameraManager.roofCam.m_Follow = playerObject.transform;
        }
    }
}

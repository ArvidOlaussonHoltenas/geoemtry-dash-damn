using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor.Build.Content;
using UnityEngine.InputSystem.LowLevel;

public class SwitchCam : MonoBehaviour
{
    [SerializeField] GameObject groundRoof;
    public Player player;
    [SerializeField] CinemachineBrain mainCamera;
    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera roofCam;

    void Update()
    {
        if (player.roof)
        {
            CameraManager.SwitchCamera(roofCam);
            groundRoof.GetComponent<BoxCollider2D>().enabled = true;
            groundRoof.SetActive(true);
        }
        else
        {
            CameraManager.SwitchCamera(normalCam);
            groundRoof.GetComponent<BoxCollider2D>().enabled = false;
            if (mainCamera.ActiveBlend.BlendWeight + 0.01 >= 1f)
            {
                groundRoof.SetActive(false);
            }
        }
    }
}

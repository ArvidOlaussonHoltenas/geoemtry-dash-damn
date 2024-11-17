using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCam : MonoBehaviour
{
    [SerializeField] GameObject groundRoof;
    public Player player;

    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera roofCam;

    void Update()
    {
        if (player.roof)
        {
            CameraManager.SwitchCamera(roofCam);
            Debug.Log("LO");
            groundRoof.SetActive(true);
        }
        else
        {
            CameraManager.SwitchCamera(normalCam);
            groundRoof.SetActive(false);
        }
    }
}

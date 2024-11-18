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

    public CinemachineBrain mainCam;
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
            StartCoroutine(WaitCoroutineAndFreeRoam(0.5f));
        }
    }

    private IEnumerator WaitCoroutineAndFreeRoam(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (CameraManager.ActiveCamera == normalCam)
        {
            groundRoof.SetActive(false);
        }
    }
}

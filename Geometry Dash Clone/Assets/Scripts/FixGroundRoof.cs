using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FixGroundRoof : MonoBehaviour
{
    [SerializeField] CinemachineBrain mainCamera;
    [SerializeField] CinemachineVirtualCamera normalCam;
    [SerializeField] CinemachineVirtualCamera roofCam;
    [SerializeField] GameObject ground;

    void Update()
    {
        transform.position = new Vector3(ground.transform.position.x, transform.position.y, transform.position.z);

        float blendPercentage = mainCamera.ActiveBlend.BlendWeight;
        if (blendPercentage + 0.01f >= 1f)
        {
            blendPercentage = 1f;
        }
        float transitionY = 0.5f * blendPercentage;

        if (normalCam.Priority == 10)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 6.5f + transitionY, transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 7f - transitionY, transform.localPosition.z);
        }
    }
}

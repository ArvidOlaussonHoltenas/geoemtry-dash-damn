using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FixGroundRoof : MonoBehaviour
{
    [SerializeField] CameraManager cameraManager;
    [SerializeField] GameObject ground;
    [SerializeField] GameObject groundRoof;
    [SerializeField] Player player;
    [SerializeField] GameObject playerObject;
    float blendPercentage;
    public float limitY;
    float transitionY;
    float infiniteX;

    void Update()
    {
        limitY = transform.localPosition.y;

        transform.localPosition = new Vector3(-playerObject.transform.position.x + infiniteX, transform.localPosition.y, transform.localPosition.z);
        if (transform.localPosition.x <= -16)
        {
            infiniteX += 16f;
        }

        if (cameraManager.mainCam.IsBlending)
        {
            blendPercentage = cameraManager.mainCam.ActiveBlend.BlendWeight;
        }
        transitionY = blendPercentage / 2;

        if (cameraManager.normalCam.Priority == 10)
        {
            if (!cameraManager.mainCam.IsBlending && transform.localPosition.y + 0.01f >= 7f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 7f, transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Max(6.5f + transitionY, limitY), transform.localPosition.z);
            }
        }
        if (cameraManager.roofCam.Priority == 10)
        {
            if (transform.localPosition.y - 0.01f <= 6.5f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 6.5f, transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Min(7f - transitionY, limitY), transform.localPosition.z);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] CameraManager cameraManager;
    [SerializeField] GameObject playerObject;
    [SerializeField] Player player;
    [SerializeField] GameObject ground;
    [SerializeField] GameObject groundRoof;
    float infiniteX = 0;
    public float limitY;
    float blendPercentage;
    float transitionY;

    void Update()
    {
        transform.localPosition = new Vector3(-playerObject.transform.position.x + infiniteX, transform.localPosition.y, transform.localPosition.z);
        if (transform.localPosition.x <= -16)
        {
            infiniteX += 16f;
        }

        limitY = transform.localPosition.y;

        if (cameraManager.mainCam.IsBlending)
        {
            blendPercentage = cameraManager.mainCam.ActiveBlend.BlendWeight;
        }
        transitionY = blendPercentage / 2;

        if (cameraManager.normalCam.Priority == 10)
        {
            if (!cameraManager.mainCam.IsBlending && transform.localPosition.y - 0.01f <= -7f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -7f, transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Min(-6.5f - transitionY, limitY), transform.localPosition.z);
            }
        }
        if (cameraManager.roofCam.Priority == 10)
        {
            if (transform.localPosition.y + 0.01f >= -6.5f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -6.5f, transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Max(-7f + transitionY, limitY), transform.localPosition.z);
            }
        }

        if (transform.position.y < -2.5f)
        {
            transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
        }
    }
}

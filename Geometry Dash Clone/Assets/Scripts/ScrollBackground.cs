using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScrollBackground : MonoBehaviour
{
    float infiniteX = 0f;

    void Update()
    {
        transform.localPosition = new Vector3(Camera.main.transform.position.x / -9 + infiniteX, (transform.localPosition.y - transform.position.y) / 5 + 7, transform.localPosition.z);
        if (transform.localPosition.x < -24)
        {
            infiniteX += 24;
        }
    }
}

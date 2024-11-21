using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimiter : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < 1.5)
        {
            transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        }
    }
}

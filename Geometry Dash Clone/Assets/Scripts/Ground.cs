using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject groundRoof;

    void Update()
    {
        transform.localPosition = new Vector3(groundRoof.transform.localPosition.x, -groundRoof.transform.localPosition.y, transform.localPosition.z);

        if (transform.position.y < -2.5f)
        {
            transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScrollBackground : MonoBehaviour
{
    [SerializeField] Player player;
    void Update()
    {
        transform.localPosition = new Vector3(Camera.main.transform.position.x / -9, (transform.localPosition.y - transform.position.y) / 5 + 7, transform.localPosition.z);
        if (transform.localPosition.x < -24)
        {
            transform.position += new Vector3(24f, 0f, 0f);
        }
    }
}

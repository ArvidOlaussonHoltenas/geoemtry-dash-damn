using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position -= new Vector3(1f, 0f, 0f) * Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x, (transform.localPosition.y - transform.position.y) / 5 + 7, transform.localPosition.z);
        if (transform.localPosition.x <= -24)
        {
            transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}

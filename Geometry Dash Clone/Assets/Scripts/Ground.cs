using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject playerObject;

    void Start()
    {
        
    }

    void Update()
    {
        float relativeX = transform.position.x - playerObject.transform.position.x;
        if (relativeX <= -16)
        {
            transform.position += new Vector3(16f, 0f, 0f);
        }
    }
}

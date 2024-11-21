using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] Player player;

    void Update()
    {
        if (transform.localPosition.x - playerObject.transform.position.x < -16)
        {
            transform.localPosition += new Vector3(16f, 0f, 0f);
        }
    }
}

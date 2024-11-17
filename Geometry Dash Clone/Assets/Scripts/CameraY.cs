using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraY : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject groundRoof;
    [SerializeField] GameObject playerObject;
    [SerializeField] Player player;
    float followX;
    float followY;

    private void Update()
    {
        followX = playerObject.transform.position.x + 2.665698f;
        followY = groundRoof.transform.position.y - ground.transform.position.y - 8.5f;
        transform.position = new Vector3(followX, followY, transform.position.z);
    }
}

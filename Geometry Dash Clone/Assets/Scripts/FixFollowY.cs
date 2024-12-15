using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixFollowY : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] Player player;

    void Update()
    {
        if (!player.roof)
        {
            transform.position = new Vector3(playerObject.transform.position.x, Mathf.Round(playerObject.transform.position.y), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerObject.transform.position.x, transform.position.y, transform.position.z);
        }

        if (transform.position.y < 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, transform.position.z);
        }
    }
}

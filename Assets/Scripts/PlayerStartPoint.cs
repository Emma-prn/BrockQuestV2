using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerMovements player;
    private CameraFollow mainCam;

    void Start()
    {
        player = FindObjectOfType<PlayerMovements>();
        player.transform.position = transform.position;

        mainCam = FindObjectOfType<CameraFollow>();
        mainCam.transform.position = new Vector3(transform.position.x, transform.position.y, mainCam.transform.position.z);
    }

    void Update()
    {
        
    }
}

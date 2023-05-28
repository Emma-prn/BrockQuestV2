using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    private BoxCollider2D boundsBox;
    private CameraFollow mainCam;

    void Start()
    {
        boundsBox = GetComponent<BoxCollider2D>();
        mainCam = FindObjectOfType<CameraFollow>();
        mainCam.SetBounds(boundsBox);
    }
}

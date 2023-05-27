using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followPlayer;
    private Vector3 targetPosition;
    public float moveSpeed;

    void Start() {

    }

    void Update() {
        targetPosition = new Vector3(followPlayer.transform.position.x, followPlayer.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}

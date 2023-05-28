using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followPlayer;
    private Vector3 targetPosition;
    public float moveSpeed;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera mainCam;
    private float halfHeihgt;
    private float halfWidth;

    private static bool camExists;

    void Start() {

        if(!camExists) {
            camExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        mainCam = GetComponent<Camera>();
        halfHeihgt = mainCam.orthographicSize;
        halfWidth = halfHeihgt * Screen.width / Screen.height;
    }

    void Update() {
        targetPosition = new Vector3(followPlayer.transform.position.x, followPlayer.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if(boundBox == null) {
            boundBox = FindObjectOfType<Bound>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }

        float clampX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeihgt, maxBounds.y - halfHeihgt);

        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }

    public void SetBounds(BoxCollider2D newBounds) {
        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }
}

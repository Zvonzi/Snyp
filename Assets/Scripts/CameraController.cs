using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target; // target kojeg prati kamera

    public Tilemap theTilemap;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    private void Start()
    {
        target = PlayerController.instance.transform; // postavljam target kojeg kamera prati na playera

        // hiding the map edges
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = theTilemap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theTilemap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        PlayerController.instance.SetBounds(theTilemap.localBounds.min, theTilemap.localBounds.max);
    }

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); // pomicanje kamere u skladu s pomicanjem targeta

        // keep the camera inside bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), 
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), 
            transform.position.z);
    }
}

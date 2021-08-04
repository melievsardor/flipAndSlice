using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float smoothSpeed = 0.025f;


    private void FixedUpdate()
    {
        Vector3 disiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, disiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

}

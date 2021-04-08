using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Transform bola;

    public float smoothSpeed;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desirePosition = bola.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(desirePosition, transform.position, smoothSpeed);

        transform.position = smoothedPosition;
    }
}

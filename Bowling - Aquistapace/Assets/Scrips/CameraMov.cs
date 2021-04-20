using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Transform bola;

    public float followLimit;
    public float smoothSpeed;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (bola.position.z <= followLimit)
        {
            Vector3 desirePosition = bola.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(desirePosition, transform.position, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}

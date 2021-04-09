using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinoPoint : MonoBehaviour
{
    public bool inTheFloor;

    private float angleLimit = 45;

    private void Start()
    {
        inTheFloor = false;
    }

    void Update()
    {
        if (Vector3.Angle(transform.up, Vector3.up) > angleLimit && inTheFloor == false)
        {
            inTheFloor = true;
        }
    }
}

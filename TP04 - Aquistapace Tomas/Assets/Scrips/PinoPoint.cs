using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinoPoint : MonoBehaviour
{
    [Header("Limits in X")]
    public float minX = -2;
    public float maxX = 2;
    [Header("Limits in Z")]
    public float minZ = 0;
    public float maxZ = 9.5f;

    [HideInInspector] public bool inTheFloor;

    private float angleLimit = 45;
    private Vector3 actualPos;

    private void Start()
    {
        inTheFloor = false;

        actualPos = transform.position;
    }

    void Update()
    {
        if (Vector3.Angle(transform.up, Vector3.up) > angleLimit && inTheFloor == false)
        {
            inTheFloor = true;
        }

        Replace();
    }

    void Replace()
    {
        if (Input.GetKeyDown("p"))
        {
            transform.position = new Vector3(Random.Range(minX, maxX), actualPos.y, Random.Range(minZ, maxZ));
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public int range = 30;
    public float impactForce = 30f;

    [HideInInspector] public bool stop;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;

        StopGame(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !stop)
        {
            ShootAction();
        }

        Exit();
    }

    void ShootAction()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, range))
        {
            string layerHit = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHit == "Pino" && hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
            }
            else
            {
                StopGame(true);
            }
        }
    }

    void Exit()
    {
        if (Input.GetButtonDown("Cancel") && stop == false)
        {
            StopGame(true);
        }
    }

    public void StopGame(bool value)
    {
        if (value)
            stop = true;
        else
            stop = false;
    }
}

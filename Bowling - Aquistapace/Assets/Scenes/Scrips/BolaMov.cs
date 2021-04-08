using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMov : MonoBehaviour
{
    [Header("Bola Data")]
    public float speed = 1;
    public float force = 1;
    private float FORCE_INCREMENT = 3;

    [Header("Limits in X")]
    public float minX;
    public float maxX;

    [HideInInspector]
    public Rigidbody rig;
    private float horizontal;
    private bool launch;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.useGravity = false;
        launch = false;
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Jump();
    }

    void FixedUpdate()
    {
        if (launch == false)
        {
            Vector3 movementHor = transform.right * horizontal * speed * Time.deltaTime;

            rig.MovePosition(rig.position + movementHor);
            rig.position = new Vector3(Mathf.Clamp(rig.position.x, minX, maxX), rig.position.y, rig.position.z);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") && launch == false)
        {
            rig.AddForce(transform.forward * force, ForceMode.VelocityChange);
            rig.useGravity = true;

            launch = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Canaleta"))
        {
            rig.AddForce(transform.forward * FORCE_INCREMENT, ForceMode.VelocityChange);
            //Debug.Log("Colisiono canaleta");
        }
    }
}

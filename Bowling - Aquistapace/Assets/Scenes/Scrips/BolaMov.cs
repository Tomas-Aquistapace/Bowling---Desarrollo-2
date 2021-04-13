using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMov : MonoBehaviour
{
    [Header("Gameplay Data")]
    public float maxThrowBola = 3;

    [Header("Bola Data")]
    public float speed = 1;
    public float force = 1;
    private float FORCE_INCREMENT = 3;
    public float minimumSpeed = 0.005f;

    [Header("Limits in X")]
    public float minX;
    public float maxX;

    [HideInInspector] public Rigidbody rig;
    [HideInInspector] public bool stop;
    [HideInInspector] public bool launch;
    [HideInInspector] public float actualShot;
    private float horizontal;
    private Vector3 spawPosition;

    void Start()
    {
        rig = GetComponent<Rigidbody>();

        spawPosition = this.transform.position;

        spawnBola();

        actualShot = 0;
    }

    void spawnBola()
    {
        rig.useGravity = false;
        launch = false;
        stop = false;

        transform.position = spawPosition;
        transform.rotation = new Quaternion(0,0,0,1);

        rig.isKinematic = true;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Stop();
        ThrowTheBall();
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

    void ThrowTheBall()
    {
        rig.isKinematic = false;

        if (Input.GetKeyDown("space") && launch == false)
        {

            rig.AddForce(transform.forward * force, ForceMode.VelocityChange);
            rig.useGravity = true;

            launch = true;
        }
    }

    void Stop()
    {
        if (rig.velocity.magnitude < minimumSpeed && (rig.velocity.magnitude != 0) && launch == true)
        {
            stop = true;
            actualShot++;

            if (actualShot < maxThrowBola)
            {
                spawnBola();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Canaleta"))
        {
            rig.AddForce(transform.forward * FORCE_INCREMENT, ForceMode.VelocityChange);
        }

        if (collision.gameObject.CompareTag("Final"))
        {
            stop = true;
            actualShot++;

            if (actualShot < maxThrowBola)
            {
                spawnBola();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMov : MonoBehaviour
{
    [Header("Gameplay Data")]
    public float maxThrowBola = 3;

    [Header("Bola Data")]
    public float horSpeed = 1;
    public float maxForce = 1;
    private float activeForce = 1;
    private float FORCE_INCREMENT = 3;
    public float minimumSpeed = 0.005f;

    [Header("Limits in X")]
    public float minX;
    public float maxX;

    [Header("Arrow Force")]
    public Transform arrowForce;

    [HideInInspector] public Rigidbody rig;
    [HideInInspector] public bool stop;
    [HideInInspector] public bool launch;
    [HideInInspector] public bool stopGame;
    [HideInInspector] public float actualShot;
    private float horizontal;
    private Vector3 spawPosition;

    void Start()
    {
        rig = GetComponent<Rigidbody>();

        spawPosition = this.transform.position;

        spawnBola();

        actualShot = 0;

        stopGame = false;
    }

    void spawnBola()
    {
        if (stopGame == false)
        {
            rig.useGravity = false;
            launch = false;
            stop = false;

            activeForce = 0;
            arrowForce.localScale = Vector3.one;

            transform.position = spawPosition;
            transform.rotation = new Quaternion(0, 0, 0, 1);

            rig.isKinematic = true;
        }
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        StopBola();
        ThrowTheBall();
    }

    void FixedUpdate()
    {
        if (launch == false && stopGame == false)
        {
            Vector3 movementHor = transform.right * horizontal * horSpeed * Time.deltaTime;

            rig.MovePosition(rig.position + movementHor);
            rig.position = new Vector3(Mathf.Clamp(rig.position.x, minX, maxX), rig.position.y, rig.position.z);
        }
    }

    void ThrowTheBall()
    {
        rig.isKinematic = false;

        if (Input.GetKey("space") && launch == false && stopGame == false)
        {
            if (activeForce < maxForce)
            {
                activeForce += Time.deltaTime * 2;

                arrowForce.localScale += new Vector3(0, 0, activeForce * Time.deltaTime * 2);
            }
        }
        else if (Input.GetKeyUp("space") && launch == false && stopGame == false)
        {
            rig.AddForce(transform.forward * activeForce, ForceMode.VelocityChange);
            rig.useGravity = true;

            launch = true;

            actualShot++;

            arrowForce.localScale = Vector3.one;
        }
    }

    void StopBola()
    {
        if (rig.velocity.magnitude < minimumSpeed && (rig.velocity.magnitude != 0) && launch == true && stopGame == false)
        {
            stop = true;

            if (actualShot < maxThrowBola)
            {
                spawnBola();
            }
            else
            {
                stopGame = true;
            }
        }
    }

    public void StopForPoints()
    {
        //actualShot = maxThrowBola;

        stopGame = true;
        stop = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Canaleta"))
        {
            rig.AddForce(transform.forward * FORCE_INCREMENT, ForceMode.VelocityChange);
        }

        if (collision.gameObject.CompareTag("Final") && stopGame == false)
        {
            stop = true;

            if (actualShot < maxThrowBola)
            {
                spawnBola();
            }
        }
    }
}

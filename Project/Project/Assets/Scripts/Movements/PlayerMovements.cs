﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //Reference to our <CharacterController>
    public CharacterController controller;
    [SerializeField] private Camera camPlayer = default;
    public EnemySpawner spawner;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Check if on ground (use to manipulate gravity)
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    public Recul animationRecul = default;


    // Update is called once per frame
    void Update()
    {
        Movements();
        Actions();
    }

    //To move in space (basically 'Brackeys' Tutorial)
    void Movements()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //To fire a ball
    void Actions()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            animationRecul.fireAnimation();
            Shoot();
        }

    }

    void Shoot()
    {
        
        if (Physics.Raycast(camPlayer.transform.position, camPlayer.transform.forward * 300f, out RaycastHit hit)) 
        {
            if (hit.transform.gameObject.layer == 9)
            {

                EnemyBehavior target = hit.transform.GetComponent<EnemyBehavior>();

                if (target != null) 
                {
                    spawner.enemyKilled();
                    target.Death(hit.point, hit.normal);
                }
            }
        }
    }

}

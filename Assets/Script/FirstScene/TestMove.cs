using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3[] positions = new Vector3[3];

    // Start is called before the first frame update
    void Start()
    {
        // Génération de la position de départ
        transform.position = positions[1];
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0,0,speed * Time.deltaTime, Space.World); //permet d'avancer sans appuyer sur une touche

        //Basic movement
        if (transform.position==positions[0])
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = positions[1];
            }
        }

        if (transform.position == positions[1])
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = positions[2];
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = positions[0];
            }
        }

        if (transform.position == positions[2])
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = positions[1];
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = positions[1];
        }
    }
}

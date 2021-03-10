using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3[] positions = new Vector3[3];

    Rigidbody r;
    bool grounded = false;
    Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        r.freezeRotation = true;
        r.useGravity = false;
        defaultScale = transform.localScale;
        // Génération de la position de départ
        transform.localPosition = positions[1];
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        if (transform.position == positions[0])
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            ObstaclesGenerator.instance.gameOver = true;
            //UIManager.instance.gameOver = true;
        }
    }
}

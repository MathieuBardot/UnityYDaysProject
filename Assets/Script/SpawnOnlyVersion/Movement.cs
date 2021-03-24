using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    public float speed = 15.0f;
    public Vector3[] positions = new Vector3[3];

    Rigidbody r;
    bool grounded = false;
    Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        defaultScale = transform.localScale;
        // Génération de la position de départ
        transform.localPosition = positions[1];
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x >= positions[2].x)
            {
                transform.position = positions[2];
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x <= positions[0].x)
            {
                transform.position = positions[0];
            }
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

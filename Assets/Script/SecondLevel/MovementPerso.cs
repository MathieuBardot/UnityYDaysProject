using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPerso : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 5.0f;
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
        jump = new Vector3(0, 2, 0);
        // Génération de la position de départ
        transform.localPosition = positions[1];
    }

    void OnCollisionStay()
    {
        grounded = true;
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

        // Jump
        if (Input.GetKeyDown(KeyCode.J) && grounded)
        {
            r.AddForce(jump * jumpForce, ForceMode.Impulse);
            grounded = false;
        }

        //Crouch
        if (Input.GetKey(KeyCode.K))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(defaultScale.x, defaultScale.y * 0.5f, defaultScale.z), Time.deltaTime * 5);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * 5);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GeneratorPlatform.instance.gameOver = true;
            //UIManager.instance.gameOver = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Vector3[] positions = new Vector3[3];
    public float timer = 0;

    public int randomNumber;
    public GameObject[] myObjects = new GameObject[3];
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            // Choose a random GameObject of the list 
            int randomObject = Random.Range(0, myObjects.Length);
            if(randomObject==0)
            {
                obstacle = GameObject.Find("Cube");
            }
            else if (randomObject == 1)
            {
                obstacle = GameObject.Find("Cube");
            }
            else if (randomObject==2)
            {
                obstacle = GameObject.Find("Cube");
            }
            //obstacle = GameObject.Find("Cube");

            // Spwan an object at a random position 
            randomNumber = Random.Range(0, positions.Length);
            obstacle.transform.position = positions[randomNumber];

            // After Spawn, move obstacle 
            if (randomNumber == 0)
            {
                // Utiliser l'animation ObstacleCouloir0
                this.GetComponent<Animation>().Play("ObstacleCouloir0");
            }
            if (randomNumber == 1)
            {
                // Utiliser l'animation ObstacleCouloir1
                this.GetComponent<Animation>().Play("ObstacleCouloir1");
            }
            if (randomNumber == 2)
            {
                // Utiliser l'animation ObstacleCouloir2
                this.GetComponent<Animation>().Play("ObstacleCouloir2");
            }

            //Set to 0 for spawn an other obstacles
            timer = 0;
        }
    }
}

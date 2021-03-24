using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObstacleSpawn : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public Vector3[] positions = new Vector3[3];
    public GameObject[] Obstacles;
    public int randomNumber;

    public void SpawnListObstacles()
    {
        DeactivateAllObstacles();

        // Choose a random GameObject of the list 
        System.Random random = new System.Random();
        int randomObject = random.Next(0, Obstacles.Length);
        Obstacles[randomObject].SetActive(true);

        // Choose at a random position for spawn
        randomNumber = Random.Range(0, positions.Length);
        Obstacles[randomObject].transform.position = positions[randomNumber];
        if (Obstacles[randomObject] == GameObject.Find("ObstacleCrouch"))
        {
            Obstacles[randomObject].transform.Translate(new Vector3(-4, 0.5f, 0));
        }
        if (Obstacles[randomObject] == GameObject.Find("ObstacleAvoid"))
        {
            Obstacles[randomObject].transform.Translate(new Vector3(2, 1, 0));
        }
    }

    public void DeactivateAllObstacles()
    {
        for (int i = 0; i < Obstacles.Length; i++)
        {
            Obstacles[i].SetActive(false);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GenerateObstacles : MonoBehaviour
{
    public Vector3[] positions = new Vector3[3];

    public GameObject[] Obstacles;

    public GameObject title;
    public GameObject gameOverText;
    public GameObject gameStartText;
    public GameObject gameRestartText;

    public TextMeshProUGUI score;
    public TextMeshProUGUI time;

    public float scoreIncrease = 10.0f;

    private float timer = 0;
    private float fullTimer = 0;

    [HideInInspector]
    public bool gameOver = false;
    bool gameStarted = false;
    float scoring = 0;

    public static GenerateObstacles instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameOverText.SetActive(false);
        gameRestartText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // En cours de partie
        if (!gameOver && gameStarted)
        {
            fullTimer += Time.deltaTime;
            timer += Time.deltaTime;
            if (timer > 3)
            {
                SpawnListObstacles();
                //transform.Translate(new Vector3(0, 0, -30));
                //Set to 0 for spawn an other obstacles
                timer = 0;
            }
            scoring += Time.deltaTime * scoreIncrease;
            score.text = $"Score : {(int)scoring}";
            time.text = $"Time : {fullTimer}";
        }

        //Lancer et relancer le jeu
        if (gameOver || !gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameOver)
                {
                    //Restart current scene
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
                else
                {
                    //Start the game
                    gameStarted = true;
                    title.SetActive(false);
                    gameStartText.SetActive(false);
                }
            }
        }
    }

    public void SpawnListObstacles()
    {
        DeactivateAllObstacles();

        // Choose a random GameObject of the list 
        System.Random random = new System.Random();
        int randomObject = random.Next(0, Obstacles.Length);
        Obstacles[randomObject].SetActive(true);

        // Choose at a random position for spawn
        int randomNumber = Random.Range(0, positions.Length);
        Obstacles[randomObject].transform.position = positions[randomNumber];
        if (Obstacles[randomObject] == GameObject.Find("ObstacleCrouch"))
        {
            Obstacles[randomObject].transform.Translate(new Vector3(-4, 0.5f, 0));
        }
        if (Obstacles[randomObject] == GameObject.Find("ObstacleAvoid"))
        {
            Obstacles[randomObject].transform.Translate(new Vector3(2, 1, 0));
        }

        // After Spawn, move obstacle 
        if (randomNumber == 0)
        {
            // Utiliser l'animation ObstacleCouloir0
            this.GetComponent<Animation>().Play("ObstacleMoveCouloirGauche");
        }
        if (randomNumber == 1)
        {
            // Utiliser l'animation ObstacleCouloir1
            this.GetComponent<Animation>().Play("ObstacleMoveCouloirMilieu");
        }
        if (randomNumber == 2)
        {
            // Utiliser l'animation ObstacleCouloir2
            this.GetComponent<Animation>().Play("ObstacleMoveCouloirDroite");
        }
    }

    public void DeactivateAllObstacles()
    {
        for (int i = 0; i < Obstacles.Length; i++)
        {
            Obstacles[i].SetActive(false);
        }
    }

    void OnGUI()
    {
        if (gameOver)
        {
            gameOverText.SetActive(true);
            title.SetActive(false);
            gameRestartText.SetActive(true);
        }
        else
        {
            if (!gameStarted)
            {
                gameOverText.SetActive(false);
                title.SetActive(true);
                gameStartText.SetActive(true);
                gameRestartText.SetActive(false);
            }
        }
    }
}
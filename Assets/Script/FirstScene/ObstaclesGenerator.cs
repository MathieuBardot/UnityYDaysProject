using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ObstaclesGenerator : MonoBehaviour
{
    public Vector3[] positions = new Vector3[3];
    
    public GameObject[] myObjects;
    GameObject obstacle;

    public GameObject title;
    public GameObject gameOverText;
    public GameObject gameStartText;
    public GameObject gameRestartText;

    public TextMeshProUGUI score;
    public TextMeshProUGUI time;

    public float scoreIncrease = 10.0f;

    private float timer = 0;
    private float fullTimer = 0;
    public int randomNumber;
    public int randomObject;

    [HideInInspector]
    public bool gameOver = false;
    bool gameStarted = false;
    float scoring = 0;

    public static ObstaclesGenerator instance;
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
                SpawnObstacles();
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

    public void SpawnObstacles()
    {
        // Choose a random GameObject of the list 
        randomObject = Random.Range(0, myObjects.Length);
        obstacle = GameObject.Find("Cube");

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
    }

    public void SpawnListObstacles()
    {
        // Choose a random GameObject of the list 
        randomObject = Random.Range(0, myObjects.Length);
        //myObjects[randomObject].SetActive(true);

        // Spwan obstacle choose at a random position
        randomNumber = Random.Range(0, positions.Length);
        myObjects[randomObject].transform.position = positions[randomNumber];
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

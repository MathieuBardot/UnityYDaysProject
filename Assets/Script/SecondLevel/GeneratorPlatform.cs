using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GeneratorPlatform : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint; //Point from where ground tiles will start
    public ObstacleSpawn tilePrefab;
    public float movingSpeed = 12;
    public int tilesToPreSpawn = 15; //How many tiles should be pre-spawned
    public int tilesWithoutObstacles = 3; //How many tiles at the beginning should not have obstacles, good for warm-up

    List<ObstacleSpawn> spawnedTiles = new List<ObstacleSpawn>();
    int nextTileToActivate = -1;

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
    static bool gameStarted = false;
    float scoring = 0;

    public static GeneratorPlatform instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameOverText.SetActive(false);
        gameRestartText.SetActive(false);

        Vector3 spawnPosition = startPoint.position;
        int tilesWithNoObstaclesTmp = tilesWithoutObstacles;
        for (int i = 0; i < tilesToPreSpawn; i++)
        {
            spawnPosition -= tilePrefab.startPoint.localPosition;
            ObstacleSpawn spawnedTile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity) as ObstacleSpawn;
            if (tilesWithNoObstaclesTmp > 0)
            {
                spawnedTile.DeactivateAllObstacles();
                tilesWithNoObstaclesTmp--;
            }
            else
            {
                spawnedTile.SpawnListObstacles();
            }

            spawnPosition = spawnedTile.endPoint.position;
            spawnedTile.transform.SetParent(transform);
            spawnedTiles.Add(spawnedTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Increase speed the higher score we get
        if (!gameOver && gameStarted)
        {
            transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * (movingSpeed + (scoring / 500)), Space.World);
            fullTimer += Time.deltaTime;
            timer += Time.deltaTime;
            scoring += Time.deltaTime * scoreIncrease;
            score.text = $"Score : {(int)scoring}";
            time.text = $"Time : {fullTimer}";
        }

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).y < 0)
        {
            //Move the tile to the front if it's behind the Camera
            ObstacleSpawn tileTmp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTmp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTmp.startPoint.localPosition;
            tileTmp.SpawnListObstacles();
            spawnedTiles.Add(tileTmp);
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

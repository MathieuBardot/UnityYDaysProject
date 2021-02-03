using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public GameObject title;
    public GameObject gameOverText;
    public GameObject gameStartText;

    public TextMeshProUGUI score;
    public TextMeshProUGUI timer;

    public float scoreIncrease = 10.0f;
    [HideInInspector]
    public bool gameOver = false;
    static bool gameStarted = false;
    float time = 0;
    float scoring = 0;

    public static GUIManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && gameStarted)
        {
            time += Time.deltaTime;
            scoring += Time.deltaTime * scoreIncrease;

            score.text = $"Score : {(int)scoring}";
            timer.text = $"Time : {time}";
        }

        if (gameOver || !gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameOver)
                {
                    //Restart current scene
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    title.SetActive(false);
                    gameStartText.SetActive(false);
                }
                else
                {
                    //Start the game
                    gameStarted = true;
                    title.SetActive(false);
                    gameOverText.SetActive(false);
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
            gameStartText.SetActive(true);
        }
        else
        {
            if (!gameStarted)
            {
                gameOverText.SetActive(false);
                title.SetActive(true);
                gameStartText.SetActive(true);
            }
        }
    }
}

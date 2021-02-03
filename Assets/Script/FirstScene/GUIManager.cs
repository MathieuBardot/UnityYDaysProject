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

    public GameObject obstacle;

    public float scoreIncrease = 10.0f;
    [HideInInspector]
    public bool gameOver = false;
    static bool gameStarted = false;
    float time = 0;
    float scoring = 0;
    // Start is called before the first frame update
    void Start()
    {
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
                    //GameOver();
                    //Restart current scene
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
                else
                {
                    //Start the game
                    gameStarted = true;
                    //GameStart();
                }
            }
        }
    }

    private void GameStart()
    {
        title.SetActive(false);
        gameOverText.SetActive(false);
        gameStartText.SetActive(false);
        enabled = false;
    }

    private void GameOver()
    {
        gameOverText.SetActive(true);
        gameStartText.SetActive(true);
        enabled = true;
    }

    void OnGUI()
    {
        if (gameOver)
        {
            gameOverText.SetActive(true);
            title.SetActive(false);
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 400, 400), "Your score is: " + ((int)scoring) + "\nYour time is: " + time);
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

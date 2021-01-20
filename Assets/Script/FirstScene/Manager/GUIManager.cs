using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public GameObject title;
    public GameObject gameOverText;
    public GameObject gameStartText;

    public GameObject obstacle;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;

        /*GameObject text = GameObject.Find("Title");
        TextMeshProUGUI tm = text.GetComponent<TextMeshProUGUI>(); ;
        tm.text = " Text modified";*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            GameEventManager.TriggerGameStart();

        // Si Collision avec un obstacle fin de partie
        if (transform.position == obstacle.transform.position)
            GameEventManager.TriggerGameOver();
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
}

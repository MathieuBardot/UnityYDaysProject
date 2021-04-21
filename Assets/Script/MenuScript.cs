using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("SecondLevel");
    }
}

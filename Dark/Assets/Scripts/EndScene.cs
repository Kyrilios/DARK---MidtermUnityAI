using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    
    public static string finalTimeToString;
    public Text resultTimeText;


    void Start()
    {
       resultTimeText.text = finalTimeToString;
    }


    public void Retry()
    {
        Debug.Log("change scene");
          SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}

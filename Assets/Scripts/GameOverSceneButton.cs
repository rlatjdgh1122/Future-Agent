using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneButton : MonoBehaviour
{
    public void GoIntro(string intro)
    {
        GameObject player = GameObject.Find("Player");
        GameObject MoveScene = GameObject.Find("MoveScene");
        GameObject Interface = GameObject.Find("Interface");    

        Destroy(player);
        Destroy(MoveScene);
        Destroy(Interface);

        SceneManager.LoadScene(intro);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

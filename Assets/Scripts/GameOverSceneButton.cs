using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneButton : MonoBehaviour
{
    public void GoIntro(string intro)
    {
        SceneManager.LoadScene(intro);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

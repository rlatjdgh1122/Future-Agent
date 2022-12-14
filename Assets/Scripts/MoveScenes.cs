using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    //public int nextSceneIndex;
    public GameObject SceneChangeObj;
    public GameObject Canvas;
    public GameObject scene;
    public GameObject player;
    public GameObject[] SetActivesgameObjects;
    int count;
    public void MoveScene()
    {
        player.transform.position = new Vector3(-5, -3.0417316f, 0);
        for (int a = 0; a < SetActivesgameObjects.Length; a++)
        {
            SetActivesgameObjects[a].SetActive(false);
        }
        if (GameObject.Find("Player"))
        {
            count++;
            Debug.Log(count);
        }
        if (count == 1)
        {
            DontDestroyOnLoad(SceneChangeObj);
            DontDestroyOnLoad(Canvas);
            DontDestroyOnLoad(scene);
        }
        else
        {
            Destroy(SceneChangeObj);
            Destroy(Canvas);
            Destroy(scene);
        }
        Scene sc = SceneManager.GetActiveScene(); //함수 안에 선언하여 사용한다.
        if (sc.name == "Eesy")
            SceneManager.LoadScene("Intro");
        if (sc.name == "Intro")
            SceneManager.LoadScene("Eesy");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    //public int nextSceneIndex;
    public GameObject[] SceneChangeObj;
    public GameObject[] SetActivesgameObjects;
    public GameObject player;

    public void MoveScene(int i)
    {
        player.transform.position = new Vector3(-5, -3.0417316f, 0);
        for (int a = 0; a < SetActivesgameObjects.Length; a++)
        {
            SetActivesgameObjects[a].SetActive(false);
        }
        for (int a = 0; a < SceneChangeObj.Length; a++)
        {
            DontDestroyOnLoad(SceneChangeObj[a]);
        }
        SceneManager.LoadScene(i);

    }

}

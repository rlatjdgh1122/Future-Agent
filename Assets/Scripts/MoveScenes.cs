using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    //public int nextSceneIndex;
    public GameObject SceneChangeObj;

    private void Start()
    {
      //  MoveScene(nextSceneIndex);
    }
    public void MoveScene(int i)
    {
        SceneManager.LoadScene(i);
        DontDestroyOnLoad(SceneChangeObj);
    }
    /*private void Start()
    {
        SceneChange();
    }
    public void SceneChange()
    {
        if (!load)
        {
            load = true;
            StartCoroutine("ChangeScene");
        }
    }

    [System.Obsolete]
    private IEnumerator ChangeScene()
    {
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Additive);
        Scene nextScene = SceneManager.GetSceneAt(1);
        for (int i = 0; i < SceneChangeObj.Length; i++)
        {
            SceneManager.MoveGameObjectToScene(SceneChangeObj[i], nextScene);
        }
        yield return null;
        SceneManager.UnloadScene(nextSceneIndex - 1);

    }*/
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Clear");
        }
    }
}

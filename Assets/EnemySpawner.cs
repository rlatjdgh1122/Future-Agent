using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy = new GameObject[3];
    [SerializeField] private int enemyCount;


    public float xRange_left;
    public float xRange_right;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(xRange_left, xRange_right), -1.05f, 1);
            Debug.Log(spawnPos);
            GameObject.Instantiate(enemy[Random.Range(0, 3)], spawnPos, Quaternion.identity).transform.parent = transform;
        }
    }
    public void SpawnBoss()
    {
        Vector3 spawnPos = new Vector3(17, -1.05f, 1);
        GameObject.Instantiate(enemy[3], spawnPos, Quaternion.identity).transform.parent = transform;
    }
}

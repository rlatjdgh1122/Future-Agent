using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy = new GameObject[3];
    [SerializeField] private int enemyCount;

    public Transform xPos;

    public Vector2 xRange;
    public Vector2 yRange;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(xRange.x, xRange.y),-1, 1);
            GameObject gameObject = Instantiate(enemy[Random.Range(0, 3)], spawnPos, Quaternion.identity);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(xPos.position, xRange);
    }
}

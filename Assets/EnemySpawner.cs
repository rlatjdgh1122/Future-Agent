using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public Animator anim;
    public static EnemySpawner Instance;
    [SerializeField] private GameObject[] enemy = new GameObject[3];
    [SerializeField] private int enemyCount;


    public float xRange_left;
    public float xRange_right;

    private void Start()
    {
        Instance = this;
        Spawn(enemyCount);
    }
    public void Spawn(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(xRange_left, xRange_right), -1.05f, 1);
            Instantiate(enemy[Random.Range(0, 3)], spawnPos, Quaternion.identity).transform.parent = transform;
        }
    }
    public void SpawnBoss(Vector3 pos)
    {
        anim.SetTrigger("IsText");
        text.text = "보스 출현!";
        Instantiate(enemy[3], pos, Quaternion.identity).transform.parent = transform;
    }
}

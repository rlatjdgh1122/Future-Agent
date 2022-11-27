using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMPro.TextMeshProUGUI CountTxt;
    public int count;
    static int sum;
    public int CountP { get => count; set { count = value; } }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        CountTxt.text = count.ToString() + "¸¶¸®";
    }
    public static void BossCount(int i)
    {
        sum += i;
        Debug.Log(sum);
        if (sum % 7 == 0)
        {
            EnemySpawner.Instance.SpawnBoss();
        }
    }
}

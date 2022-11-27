using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] StageExit;
    public static GameManager Instance;
    public TMPro.TextMeshProUGUI CountTxt;
    public TMPro.TextMeshProUGUI txt;
    public Animator anim;
    public int count;
    static int sum = 0;
    int bossDieCount = 0;
    public int CountP { get => count; set { count = value; } }
    private void Awake()
    {
        Instance = this;
        sum = 0;
    }
    private void Update()
    {
        CountTxt.text = count.ToString() + "마리";
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
    public void BossDie(int i)
    {
        bossDieCount += i;
        if(bossDieCount == 1)
        {
            anim.SetTrigger("IsText");
            txt.text = "stage1 클리어!";
            StageExit[0].SetActive(true);
        }
        if(bossDieCount == 2)
        {
            anim.SetTrigger("IsText");
            txt.text = "stage2 클리어!";
            StageExit[1].SetActive(true);
        }
    }
}

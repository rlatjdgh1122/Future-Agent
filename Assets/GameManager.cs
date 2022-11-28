using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] StageExit;
    public static GameManager Instance;
    public TMPro.TextMeshProUGUI CountTxt;
    public TMPro.TextMeshProUGUI txt;

    public Transform bossPos1;
    public Transform bossPos2;
    public Transform bossPos3;

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
    public void BossCount(int i)
    {
        sum += i;
        if (sum == 7)
        {
            EnemySpawner.Instance.SpawnBoss(bossPos1.position);
        }else if(sum == 17)
        {
            EnemySpawner.Instance.SpawnBoss(bossPos2.position);
        }
        else if(sum == 27) EnemySpawner.Instance.SpawnBoss(bossPos3.position);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
    public int Stage;
    public int Stage2_enemtCount = 10;
    public int Stage3_enemtCount = 10;

    public TMPro.TextMeshProUGUI txt;
    public Animator anim;

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public Transform pos;

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            if (Stage == 1)
            {   
                OpenStage2();
                EnemySpawner.Instance.Spawn(Stage2_enemtCount);
            }
            if(Stage == 2)
            {
                OpenStage3();
                EnemySpawner.Instance.Spawn(Stage3_enemtCount);
            }

        }
    }
    public void OpenStage2()
    {
        anim.SetTrigger("IsText");
        txt.text = "Stage2";

        player.transform.position = pos.position;
        stage2.SetActive(true);

        stage1.SetActive(false);
        stage3.SetActive(false);
    }
    public void OpenStage3()
    {
        anim.SetTrigger("IsText");
        txt.text = "Stage3";

        player.transform.position = pos.position;
        stage3.SetActive(true);

        stage1.SetActive(false);
        stage2.SetActive(false);
    }
}

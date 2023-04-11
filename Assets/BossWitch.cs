using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWitch : MonoBehaviour
{
    public GameObject image;

    BossRotation bossRotation;
    // Update is called once per frame
    private void Start()
    {
       // image = GameObject.FindGameObjectWithTag("rotation");
        bossRotation = GetComponent<BossRotation>();
    }
    void Update()
    {
        if (GameObject.Find("boss(Clone)") != null)
        {
            image.SetActive(true);
            bossRotation.enabled = true;
        }
        if(GameObject.Find("boss(Clone)") == null) { image.SetActive(false); bossRotation.enabled = false; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    public GameObject image;
    public GameObject Obj;
    public GameObject[] FindObjects;
    public Vector2 dir;
    public float shortDis;
    void OnEnable()
    {
        //image = GameObject.FindGameObjectWithTag("rotation").transform.GetChild(0).gameObject;
        //.SetActive(true);
        Obj = GameObject.FindGameObjectWithTag("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
        FindObjects = GameObject.FindGameObjectsWithTag("Enemy");
        shortDis = Vector3.Distance(image.transform.position, Obj.transform.position);

        foreach (GameObject found in FindObjects)
        {
            float Distance = Vector3.Distance(image.transform.position, found.transform.position);
            if (Distance < shortDis)
            {
                Obj = found;
                shortDis = Distance;

            }
            dir = image.transform.position - Obj.transform.position;
            float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            image.transform.rotation = Quaternion.Euler(0, 0, z);
        }

    }
}

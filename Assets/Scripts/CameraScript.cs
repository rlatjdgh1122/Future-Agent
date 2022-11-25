using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Follow;
    void Start()
    {
        transform.Translate(new Vector3(Follow.transform.position.x, Follow.transform.position.y, -10));
    }
}

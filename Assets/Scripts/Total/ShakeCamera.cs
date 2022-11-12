using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeCamera : MonoBehaviour
{
    public static new Animator camera;

    public Camera Cam;
    public  bool ZoomActive;
    public Vector3[] target;
    public float Speed;
    private void Start()
    {
        camera = GetComponent<Animator>();
        Cam = Camera.main;
    }
    public void Shake()
    {
        camera.SetTrigger("Shake");
    }
    private void LateUpdate()
    {
        if (ZoomActive)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, Speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, target[1], Speed);
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, 0.3f);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, target[0], 0.3f);
        }

    }
}

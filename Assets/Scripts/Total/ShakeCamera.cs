using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public static new Animator camera;
    private static Animator C => camera;

    private void Start()
    {
        camera = GetComponent<Animator>();
    }
    public void Shake()
    {
        camera.SetTrigger("Shake");
    }
}

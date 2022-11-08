using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private float shakeTime;
    private float shakeIntensity;
    private static ShakeCamera instance;
    public static ShakeCamera Instance => instance;
    public ShakeCamera()
    {
        instance = this;
    }
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("Shake");
        StartCoroutine("Shake");
    }
    
    /*private IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;

        
    }*/
}

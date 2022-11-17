using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera Instance { get; private set; }
    public float shakeTimer;

    public bool ZoomActive;
    public float ZoomSpeed;
    CinemachineVirtualCamera cinemachineVirtual;
    private void Start()
    {
        Instance = this;
        cinemachineVirtual = GetComponent<CinemachineVirtualCamera>();
    }
    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
       cinemachineVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                   cinemachineVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
        if (ZoomActive)
            cinemachineVirtual.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineVirtual.m_Lens.OrthographicSize, 4, ZoomSpeed);

        if (!ZoomActive)
            cinemachineVirtual.m_Lens.OrthographicSize = Mathf.Lerp(cinemachineVirtual.m_Lens.OrthographicSize, 5, ZoomSpeed);
    }

}

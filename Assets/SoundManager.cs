using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instace;
    [SerializeField] private AudioSource BG_Source;
    [SerializeField] private AudioSource EF_Source;
    public AudioClip[] cd;
    private void Awake()
    {
        Instace = this;
    }
    public void BG_Volume(float volume)
    {
        BG_Source.volume = volume;
    }
    public void EF_Volume(float volume)
    {
        EF_Source.volume = volume;
    }
    public void EffectPlay(int index, float delay)
    {
        EF_Source.clip = cd[index];
        StartCoroutine(SoundDelay(index, delay));
    }
    private IEnumerator SoundDelay(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        EF_Source.PlayOneShot(cd[index]);
    }
}

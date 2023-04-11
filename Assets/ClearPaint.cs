using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPaint : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public TMPro.TextMeshProUGUI TIMEtext;
    public float sec;
    public int min;
    void Start()
    {
        min = PlayerPrefs.GetInt("Min", 0);
        sec = PlayerPrefs.GetFloat("Sec", 0);

        TIMEtext.text = string.Format($"{min}:{(int)sec}");
        StartCoroutine("ColorTransform");
    }

    IEnumerator ColorTransform()
    {
        while (true)
        {
            text.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            text.color = Color.yellow;
            yield return new WaitForSeconds(0.1f);
            text.color = Color.blue;

        }
    }
}

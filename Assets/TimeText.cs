using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    [SerializeField] float Second;
    [SerializeField] int Minit;
    [SerializeField] TMPro.TextMeshProUGUI timeText;
    bool maxMinit = true;
    public bool isTimer = true;

    private void Start()
    {
        isTimer = true;
    }

    void Update()
    {
        if (maxMinit && isTimer)
        {
            SetTimer();
        }
    }



    public void SetTimer()
    {
        Second += Time.deltaTime;

        timeText.text = string.Format("{0:D2}:{1:D2}", Minit, (int)Second);

        if ((int)Second > 59)
        {
            Second = 0;
            Minit++;
        }

        if (Minit >= 10)
        {
            timeText.text = string.Format("{0:D2}:{1:D2}", 10, 00);
            maxMinit = false;
        }
    }
}
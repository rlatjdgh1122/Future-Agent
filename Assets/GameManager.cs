using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMPro.TextMeshProUGUI CountTxt;
    public int count;
    public int CountP { get => count; set { count = value; } }
    private void Awake()
    {
        Instance = this;
        StartCoroutine("Text");
    }
   /* private IEnumerator Text()
    {
        while (true)
        {
            CountTxt.text = count.ToString() + "¸¶¸®";
            if(count % 7 == 0)
            {
                
            }
        }
    }*/
}

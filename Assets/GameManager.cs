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
    }
    private void Update()
    {
        CountTxt.text = count.ToString() +"¸¶¸®";
    }
}

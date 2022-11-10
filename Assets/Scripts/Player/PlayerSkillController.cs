using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSkillController : MonoBehaviour
{
    public UnityEvent[] unityAction = new UnityEvent[4];
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            unityAction[0]?.Invoke();   
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            unityAction[1]?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            unityAction[2]?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            unityAction[3]?.Invoke();
        }
    }
}

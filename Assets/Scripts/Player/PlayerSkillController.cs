using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSkillController : MonoBehaviour
{
    public UnityAction unityAction;
    SkillMethod skillMethod = new SkillMethod();
    private void Awake()
    {
        unityAction += skillMethod.Print;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            unityAction.Invoke();
        }
    }
}

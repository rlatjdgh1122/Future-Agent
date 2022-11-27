using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideButtonManager : MonoBehaviour
{
    [SerializeField] GameObject guidePanel; 
    public void OpenPanel()
    {
        guidePanel.SetActive(!guidePanel.gameObject.activeSelf);
    }
    public void ClosePanel()
    {
        guidePanel.SetActive(false);
    }
}

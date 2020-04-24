using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEverydayPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    Events events = Events.getInstance();

    private void Awake()
    {
        events.OpenOrCloseEveryDay += OpenOrClosePanel;
    }
    private void OnApplicationQuit()
    {
        events.OpenOrCloseEveryDay -= OpenOrClosePanel;
    }
    private void OpenOrClosePanel(bool state)
    {
        _panel.SetActive(state);
    }
    
}

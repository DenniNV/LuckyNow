using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    private Events events = Events.getInstance();

    private void Start()
    {
        events.OpenPanelLastPick += Open;
    }
    public void Open()
    {
        _panel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _panelLastPick;
    [SerializeField]
    private GameObject _panelFristPick;

    private Events events = Events.getInstance();

    private void Start()
    {
        events.OpenPanelLastPick += Open;
    }
    public void Open()
    {
        _panelLastPick.SetActive(true);
        _panelFristPick.SetActive(false);
    }
}

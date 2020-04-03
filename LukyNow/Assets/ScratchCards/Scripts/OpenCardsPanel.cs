using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardsPanel : MonoBehaviour
{
  
    [SerializeField]private GameObject _firstPanel;
    [SerializeField]private GameObject _secondPanel;
    [SerializeField]private GameObject _scratchCardPanel;
    [SerializeField]private GameObject _scratchCardSelector;
    private Events events = Events.getInstance();


    private void OnEnable()
    {
        events.OpenOrClose += OpenOrClose;
    }
    private void OnDisable()
    {
        events.OpenOrClose -= OpenOrClose;
    }

    public void OpenOrClose(bool state)
    {
        _firstPanel.SetActive(state);
        _secondPanel.SetActive(!state);
        _scratchCardPanel.SetActive(true);
        _scratchCardSelector.SetActive(false);
        events.Interactable(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitWinning : MonoBehaviour
{
    [SerializeField] private GameObject[] _closeGameObjects;
    [SerializeField] private GameObject[] _openGameObjects;
    private Events events = Events.getInstance();
    private void Close()
    {
        for (int i = 0; i < _closeGameObjects.Length; i++)
        {
            _closeGameObjects[i].SetActive(false);
        }
    }

    private void Open()
    {
        for (int i = 0; i < _openGameObjects.Length; i++)
        {
            _openGameObjects[i].SetActive(true);
        }
    }

    public void OpenWait()
    {
        Close();
        Open();
        events.Interactable(true);
        TimeView.StartTime();
    }

    

}

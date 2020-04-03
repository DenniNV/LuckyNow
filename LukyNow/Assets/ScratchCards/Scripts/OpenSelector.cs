using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSelector : MonoBehaviour
{
    [SerializeField] private GameObject _cardRepository;
    [SerializeField] private GameObject _cardSelector;
    private Events events = Events.getInstance();
    private void OnEnable()
    {
        events.OpenCardSelector += OpenSelecorAndCloseCardRepository;
    }
    private void OnDisable()
    {
        events.OpenCardSelector -= OpenSelecorAndCloseCardRepository;
    }

    private void OpenSelecorAndCloseCardRepository()
    {
        _cardRepository.SetActive(false);
        _cardSelector.SetActive(true);
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour
{
    private Events _events = Events.getInstance();
    [SerializeField] private Button _buttonInteractable;
    private void Awake()
    {
        _events.ButtonState += InteractableButtonState; 
    }
    private void OnApplicationQuit()
    {
        _events.ButtonState -= InteractableButtonState;
    }

    private void InteractableButtonState( bool state)
    {
        _buttonInteractable.interactable = state;
    }
}

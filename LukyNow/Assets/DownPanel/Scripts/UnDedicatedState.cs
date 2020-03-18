using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnDedicatedState : IButtonState
{
    public void Dedicated(ButtonView buttonView)
    {
        buttonView.ButtonState = new DedicatedState();
    }

    public void UnDedicated(ButtonView buttonView)
    {
        buttonView.Circle.enabled = false;
        buttonView.MenuButton.sprite = buttonView.State[1];
        buttonView.GamePanel.SetActive(false);
    }
}

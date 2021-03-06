﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedicatedState : IButtonState
{
   

    public void Dedicated(ButtonView buttonView)
    {
        buttonView.Circle.enabled = true;
        buttonView.MenuButton.sprite = buttonView.State[1];
        buttonView.ButtonName.color = new Color(255 , 0, 122);
        buttonView.GamePanel.SetActive(true);
    }

    public void UnDedicated(ButtonView buttonView)
    {
        buttonView.ButtonState = new UnDedicatedState();
    }
}

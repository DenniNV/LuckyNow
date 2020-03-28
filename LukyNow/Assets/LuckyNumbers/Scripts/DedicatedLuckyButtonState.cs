using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DedicatedLuckyButtonState : ILuckyNumbersState
{
    public void Dedicated(LuckyButtonsView luckyButtons)
    {
        luckyButtons.ButtonImage.sprite = luckyButtons.PickButton;
        luckyButtons.ButtonInteractable.interactable = false;

    }
    public void UnDedicated(LuckyButtonsView luckyButtons)
    {
        luckyButtons.LuckyNumbersState = new UnDedicatedLuckyButtonState();

    }

  
}

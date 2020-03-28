using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnDedicatedLuckyButtonState : ILuckyNumbersState
{
    public void Dedicated(LuckyButtonsView luckyButtons)
    {
        luckyButtons.LuckyNumbersState = new DedicatedLuckyButtonState();
    }
    public void UnDedicated(LuckyButtonsView luckyButtons)
    {
        luckyButtons.ButtonImage.sprite = luckyButtons.UnPickButton;
        luckyButtons.ButtonInteractable.interactable = true;
    }
}

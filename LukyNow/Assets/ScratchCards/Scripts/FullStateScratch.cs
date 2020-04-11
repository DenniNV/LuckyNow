using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullStateScratch : ICardState
{
    private Events _events = Events.getInstance();
    private RewardPanel rewardPanel = RewardPanel.getInstance();
    public void FullScratchState(IGetCardSettings card)
    {
         rewardPanel.AddReward(card.GetReward().RewardCoin, card.GetReward().RewardDollar);
         card.WinIndex = 0;
        _events.Interactable(true);
        _events.OpenSelector();
        _events.Remove();
        _events.Clear();
    }

    public void FullUnScratchState(IGetCardSettings card)
    {
        card.State = new FullScratchStateUn();
    }
}

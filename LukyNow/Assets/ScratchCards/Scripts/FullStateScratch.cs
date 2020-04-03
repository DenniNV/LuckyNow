using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullStateScratch : ICardState
{
    private Events _events = Events.getInstance();
    private RewardAccrual _rewardAccrual = new RewardAccrual();
    public void FullScratchState(IGetCardSettings card)
    {
        _rewardAccrual.Accrual(card.GetReward().RewardCoin, card.GetReward().RewardDollar);
         card.WinIndex = 0;
        _events.Interactable(true);
        _events.OpenSelector();
        _events.Remove();
    }

    public void FullUnScratchState(IGetCardSettings card)
    {
        card.State = new FullScratchStateUn();
    }
}

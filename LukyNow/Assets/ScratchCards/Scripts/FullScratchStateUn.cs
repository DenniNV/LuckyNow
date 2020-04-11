using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScratchStateUn : ICardState
{
    private Events _events = Events.getInstance();
    public void FullScratchState(IGetCardSettings card)
    {
        card.State = new FullStateScratch();
    }

    public void FullUnScratchState(IGetCardSettings card)
    {
        card.WinIndex = 0;
        _events.Interactable(true);
    }
}

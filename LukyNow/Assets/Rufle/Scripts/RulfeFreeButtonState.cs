using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulfeFreeButtonState : IRufleButtonFreeState
{
    RufleCount rufleCount = RufleCount.getInstance();
    public void RufleBuyState(RufleButtonView view)
    {
        //view.State = new RufleBuyButtonState();
    }

    public void RufleFreeState(RufleButtonView view)
    {
        //view.ButtonText.text = "FREE TICKETS";
        //Debug.Log("Free");
        

    }
   
}

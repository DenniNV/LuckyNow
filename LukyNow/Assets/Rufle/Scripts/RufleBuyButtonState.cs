using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class RufleBuyButtonState : IRufleButtonFreeState
{
    public void RufleBuyState(RufleButtonView view)
    {
        //view.ButtonText.text = "BUY TICKETS";
        //view.PanelBuy.SetActive(true);
        //Debug.Log("BuyPanel");
    }
    public void RufleFreeState(RufleButtonView view)
    {
        //view.State = new RulfeFreeButtonState();
    }

   

}


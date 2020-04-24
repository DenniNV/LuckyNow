using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEvertdayUnReceived : IStateRewardEveryday
{
    public void NextReceived(RewardEverydayView view)
    {
        view.State = new StateEverydayRewardReceived();
    }

    public void Received(RewardEverydayView view)
    {
        view.State = new StateEverydayRewardReceived();
    }

    public void UnRecived(RewardEverydayView view)
    {
        view.Background.sprite = view.Sprite[0];
        view.Arrow.gameObject.SetActive(false);
        view.CloseOrOpenText(true);
    }

   
}

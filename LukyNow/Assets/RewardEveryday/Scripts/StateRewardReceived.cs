using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEverydayRewardReceived : IStateRewardEveryday
{
    public void NextReceived(RewardEverydayView view)
    {
        view.Background.sprite = view.Sprite[2];
    }

    public void Received(RewardEverydayView view)
    {

        view.Background.sprite = view.Sprite[1];
        view.Arrow.gameObject.SetActive(true);
        view.CloseOrOpenText(false);
    }

    public void UnRecived(RewardEverydayView view)
    {
        view.State = new StateEvertdayUnReceived();
    }
}

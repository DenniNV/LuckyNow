using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCardReward : MonoBehaviour
{
    private RewardPanel _rewardPanel = RewardPanel.getInstance();
    private Events _events = Events.getInstance();
    private Reward _reward = new ScratchReward(0, 50);
    private void OnEnable()
    {
        _events.ProgressInScratchSmallCard += Reward;
    }
    private void OnDisable()
    {
        _events.ProgressInScratchSmallCard -= Reward;
    }


    private void Reward()
    {
        _rewardPanel.AddReward(_reward.RewardCoin , _reward.RewardDollar);
        _events.Remove();
        _events.Clear();
        _events.OpenSelector();
    }




}

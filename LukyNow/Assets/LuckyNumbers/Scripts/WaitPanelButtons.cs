﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaitPanelButtons : MonoBehaviour
{

    [SerializeField] private Button _close;
    [SerializeField] private Button _rewardButton;
    [SerializeField] private Button _skipTime;
    [SerializeField] private Button _checkWinOrLose;
    [SerializeField] private GameObject[] _closeObject;
    [SerializeField] private GameObject[] _openObject;
    private Events _events = Events.getInstance();
    private readonly Reward _reward = new RewardInLuckyNumbers(5000, 0.5);
    private RewardAccrual _rewardAccrual = new RewardAccrual();
    private RewardPanel rewardPanel = RewardPanel.getInstance();
    public void RewardAccrual()
    {
        rewardPanel.AddReward(_reward.RewardCoin , _reward.RewardDollar);
        TryAgain();
    }
    private void OnEnable()
    {
        _events.YouWin += WhenDidYouWinOrLose;
        _events.WaitTimeEnd += EnableCheckWinOrLoseButton;
    }
    private void OnDisable()
    {
        _events.YouWin -= WhenDidYouWinOrLose;
        _events.WaitTimeEnd -= EnableCheckWinOrLoseButton;
    }
    private void EnableCheckWinOrLoseButton()
    {
        _checkWinOrLose.gameObject.SetActive(true);
    }
    public void WhenDidYouWinOrLose(bool state)
    {
        _checkWinOrLose.gameObject.SetActive(false);
        _close.gameObject.SetActive(!state);
        _rewardButton.gameObject.SetActive(state);
        _skipTime.gameObject.SetActive(!state);
    }
    public void TryAgain()
    {
        _events.TryAgain();
        for (int i = 0; i < _closeObject.Length; i++)
        {
            _closeObject[i].SetActive(false);
        }
        for (int i = 0; i < _openObject.Length; i++)
        {
            _openObject[i].SetActive(true);
        }
    }
    public void SkipTime()
    {
        // Вызов рекламы
        _events.SkipTime();
    }
}

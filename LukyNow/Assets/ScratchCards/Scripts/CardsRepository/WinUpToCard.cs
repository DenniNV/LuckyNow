﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUpToCard : MonoBehaviour, IGetCardSettings
{
    [SerializeField] private BigCardView _cardView;
    [SerializeField] private Sprite _card;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private ScratchCardManager _scratchManager;
    private Reward _reward = new ScratchReward(0, 300);
    private Events _events = Events.getInstance();

    private void OnEnable()
    {
        _events.ProgressInScratchBigCard += CheckWinOrLose;
    }
    private void OnDisable()
    {
        _events.ProgressInScratchBigCard -= CheckWinOrLose;
    }

    private void CheckWinOrLose()
    {
        if (WinIndex == 1)
        {
            State = new FullStateScratch();
            State.FullScratchState(this);
        }
        else
        {
            State = new FullScratchStateUn();
            State.FullUnScratchState(this);
        }
    }
    #region implemented interface
    public Sprite GetSprite()
    {
        return _card;
    }

    public void Setup()
    {
        _cardView.SetupSprite(this, true);
    }

    public ScratchCardManager GetScratchCardManager()
    {
        return _scratchManager;
    }

    public Reward GetReward()
    {
        return _reward;
    }
    public int WinIndex { get => _winIdex; set => _winIdex = value; }
    public ICardState State { get; set; }

    private int _winIdex;


    public GameObject GetPrefab()
    {
        _winIdex = Random.Range(0, 2);
        return _prefabs[_winIdex];
    }
    #endregion
}

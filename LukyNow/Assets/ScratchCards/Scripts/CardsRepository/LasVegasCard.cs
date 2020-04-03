using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasVegasCard : MonoBehaviour, IGetCardSettings 
{
    [SerializeField] private CardView _cardView;
    [SerializeField] private Sprite _card;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private ScratchCardManager _scratchManager;
    private Reward _reward = new ScratchReward(0, 300);
    private Events _events = Events.getInstance();

    private void OnEnable()
    {
        _events.ProgressInScratch += CheckWinOrLose;
    }
    private void OnDisable()
    {
        _events.ProgressInScratch -= CheckWinOrLose;
    }

    private void CheckWinOrLose()
    {
        if (_winIdex == 1)
        {
            State = new FullStateScratch();
            State.FullScratchState(this);
            State = null;
        }
        else
        {
            State = new FullScratchStateUn();
            State.FullUnScratchState(this);
            State = null;
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
        _winIdex = Random.Range(0, 5);
        if (_winIdex == 1)
        {
            return _prefabs[_winIdex];
        }
        else
        {
            return _prefabs[0];
        }
    }
    #endregion
}

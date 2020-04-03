using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardViewPanel : MonoBehaviour
{
    [SerializeField] private Text _rewardText;
    private RewardAccrual rewardAccrual = new RewardAccrual();
    private double _rewardCoin;
    private int _rewardDollar;
    RewardPanel panel = RewardPanel.getInstance();
    public double RewardCoin { set => _rewardCoin = value; get => _rewardCoin; }
    public int RewrdDollar { set => _rewardDollar = value; get =>_rewardDollar;}
    public Text RewardText { set; get; }

    private void Awake()
    {
        panel.Constructor(this);
    }
    private void Start()
    {
        panel.Constructor(this);
        ClosePanel();
    }
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
    public void UpdateText()
    {
        _rewardText.text = "You aern " + _rewardCoin + " coins" + _rewardDollar + " dollars";
    }
    public void RewardGetOne()
    {
        rewardAccrual.Accrual(_rewardCoin, _rewardDollar);
        ClosePanel();
    }
    public void RewardGetDouble()
    {
        rewardAccrual.Accrual(_rewardCoin*2, _rewardDollar*2);
        ClosePanel();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyWheel : MonoBehaviour
{

    private bool _isStarted;
    private float[] _sectorsAngles = new float[20];
    private float _finalAngle;
    private float _startAngle = 0;
    private float _currentLerpRotationTime;
    public GameObject Circle;
    public GameObject[] RewardsIcon;
    public int CurrentCoinsAmount = 1000;
    public int PreviousCoinsAmount;
    public int TurnCost = 0;
    private Price _price = new PriceLuckyWheel(2000);
    private Buy _buy;
    private RewardPanel _rewardPanel = RewardPanel.getInstance();
    private Reward[] _rewards =
    {
        new RewardLuckyWheel(0,0,0),
        new RewardLuckyWheel(5,0,-18),
        new RewardLuckyWheel(4.5,0,-36),
        new RewardLuckyWheel(0,3000*0.00001,-54),
        new RewardLuckyWheel(0,10000*0.00001,-72),
        new RewardLuckyWheel(0,0,-90),
        new RewardLuckyWheel(1,0,-108),
        new RewardLuckyWheel(0,5500*0.00001,-126),
        new RewardLuckyWheel(0,7000*0.00001,-144),
        new RewardLuckyWheel(0,10,-162),
        new RewardLuckyWheel(2000,0,-180),
        new RewardLuckyWheel(0,50000*0.00001,-198),
        new RewardLuckyWheel(0,1500*0.00001,-216),
        new RewardLuckyWheel(0,3*0.00001,-234),
        new RewardLuckyWheel(60000,0,-252),
        new RewardLuckyWheel(0,4000*0.00001,-270),
        new RewardLuckyWheel(0,500*0.00001,-288),
        new RewardLuckyWheel(0,1000*0.00001,-306),
        new RewardLuckyWheel(0,50*0.00001,-324),
        new RewardLuckyWheel(0,3500*0.00001,-342),
    };
    private Events _events = Events.getInstance();


    private void Awake()
    {
        _buy = new Buy(_price);   
    }
    public void TurnWheel()
    {
        try
        {
            _buy.BuySomething();
            if (CurrentCoinsAmount >= TurnCost)
            {
                _events.Interactable(false);
                _currentLerpRotationTime = 0f;
                for (int i = 0; i <= 19; i++)
                {
                    _sectorsAngles[i] = 18 * i;
                }
                int fullCircles = 12;
                float randomFinalAngle = _sectorsAngles[Random.Range(0, _sectorsAngles.Length)];
                _finalAngle = -(fullCircles * 360 + randomFinalAngle);
                _isStarted = true;
                PreviousCoinsAmount = CurrentCoinsAmount;
                CurrentCoinsAmount -= TurnCost;
            }
        }
        catch
        {
            Debug.Log("предложение показа рекламы");
            return;
        }
        
    }
    public void GiveAwardByAngle()
    {
        foreach(RewardLuckyWheel r in _rewards)
        {
            if(r.Angle == _startAngle)
            {
                _rewardPanel.AddReward(r.RewardCoin, r.RewardDollar);
            }
        }
    }
    void Update()
    {
        if (!_isStarted)
            return;
        Spin();
    }

    private void Spin()
    {
        float maxLerpRotationTime = 12f;
        _currentLerpRotationTime += Time.deltaTime;
        if (_currentLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.z == _finalAngle)
        {
            _currentLerpRotationTime = maxLerpRotationTime;
            _isStarted = false;
            _startAngle = _finalAngle % 360;
            GiveAwardByAngle();
            _events.Interactable(true);
        }
        float t = _currentLerpRotationTime / maxLerpRotationTime;
        t = t * t * t * (t * (6f * t - 15f) + 10f);
        float angle = Mathf.Lerp(_startAngle, _finalAngle, t);
        Circle.transform.eulerAngles = new Vector3(0, 0, angle);
        for (int i = 0; i < RewardsIcon.Length; i++)
        {
            RewardsIcon[i].transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

}

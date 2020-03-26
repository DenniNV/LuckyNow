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
    private Reward[] rewards =
    {
        new RewardLuckyWheel(0,0,0),
        new RewardLuckyWheel(5,0,-18),
        new RewardLuckyWheel(4.5,0,-36),
        new RewardLuckyWheel(3000,0,-54),
        new RewardLuckyWheel(0,10000,-72),
        new RewardLuckyWheel(0,0,-90),
        new RewardLuckyWheel(1,0,-108),
        new RewardLuckyWheel(0,5500,-126),
        new RewardLuckyWheel(0,7000,-144),
        new RewardLuckyWheel(0,10,-162),
        new RewardLuckyWheel(2000,0,-180),
        new RewardLuckyWheel(0,50000,-198),
        new RewardLuckyWheel(0,1500,-216),
        new RewardLuckyWheel(0,3,-234),
        new RewardLuckyWheel(60000,0,-252),
        new RewardLuckyWheel(0,4000,-270),
        new RewardLuckyWheel(0,500,-288),
        new RewardLuckyWheel(0,1000,-306),
        new RewardLuckyWheel(0,50,-324),
        new RewardLuckyWheel(0,3500,-342),
    };

    private readonly RewardAccrual rewardAccrual = new RewardAccrual();
    private Events _events = Events.getInstance();
    
    public void TurnWheel()
    {
        if (CurrentCoinsAmount >= TurnCost)
        {
            _events.Interactable(false);
            _currentLerpRotationTime = 0f;
            for(int i =0; i<=19; i++)
            {
                _sectorsAngles[i] = 18 *i;
            }
            int fullCircles = 12;
            float randomFinalAngle = _sectorsAngles[Random.Range(0, _sectorsAngles.Length)];
            _finalAngle = -(fullCircles * 360 + randomFinalAngle);
            _isStarted = true;
            PreviousCoinsAmount = CurrentCoinsAmount;
            CurrentCoinsAmount -= TurnCost;
        }
    }
    public void GiveAwardByAngle()
    {
        foreach(RewardLuckyWheel r in rewards)
        {
            if(r.Angle == _startAngle)
            {
                rewardAccrual.Accrual(r.RewardCoin, r.RewardDollar); 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyWheel : MonoBehaviour
{

    private bool _isStarted;
    private float[] _sectorsAngles = new float[20];
    private float _finalAngle;
    private float _startAngle = 0;
    private float _currentLerpRotationTime;
    public GameObject Circle;
    public int CurrentCoinsAmount = 1000;
    public int PreviousCoinsAmount;
    public int TurnCost = 0;
    private Reward[] rewards = new RewardLuckyWheel[20];
    private Score _score = Score.getInstance();

    private void Start()
    {
        for(int i = 0; i<rewards.Length; i++)
        {
            rewards[i] = new RewardLuckyWheel(i, i*10, -18 * i);
        }
    }
    public void TurnWheel()
    {
        if (CurrentCoinsAmount >= TurnCost)
        {
            _currentLerpRotationTime = 0f;
            //_sectorsAngles = new float[] { 20, 40, 60, 80, 100, 120, 140, 1, 270, 300, 330, 360 };
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
                Debug.Log(r.RewardDollar);
                Debug.Log(r.RewardCoin);
                _score.Dollar = r.RewardDollar;
                _score.Coin = r.RewardCoin;
            }
        }
    }
    void Update()
    {
        if (!_isStarted)
            return;
        float maxLerpRotationTime = 8f;
        _currentLerpRotationTime += Time.deltaTime;
        if (_currentLerpRotationTime > maxLerpRotationTime || Circle.transform.eulerAngles.z == _finalAngle)
        {
            _currentLerpRotationTime = maxLerpRotationTime;
            _isStarted = false;
            _startAngle = _finalAngle % 360;

            GiveAwardByAngle();
           
        }
        float t = _currentLerpRotationTime / maxLerpRotationTime;
        t = t * t * t * (t * (6f * t - 15f) + 10f);
        float angle = Mathf.Lerp(_startAngle, _finalAngle, t);
        Circle.transform.eulerAngles = new Vector3(0, 0, angle);
    }


}

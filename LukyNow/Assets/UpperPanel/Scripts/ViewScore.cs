using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewScore : MonoBehaviour
{
    private Events _event = Events.getInstance();
    private Score _score = Score.getInstance();
    private Save _save = new Save();
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _dollarText;

    
    private void Start()
    {

        if (PlayerPrefs.HasKey(_save.SaveKey))
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString(_save.SaveKey));
            _score.Coin = _save._saveCoins;
            _score.Dollar = _save._saveDollars;
        }
        else
        {
            _score.PlusMoney(400000000 , 0);
        }
        UpdateCoinText(_score.Coin);
        UpdateDollarText(_score.Dollar);
        _event.UpDollar += UpdateDollarText;
        _event.UpCoin += UpdateCoinText;
    }

    private void UpdateCoinText(double newCoin)
    {

        _coinText.text = "" + newCoin;
    }

    private void UpdateDollarText(double newDollar)
    {

        _dollarText.text = "" + newDollar;
    }

    private void OnApplicationQuit()
    {
        _save._saveCoins = _score.Coin;
        _save._saveDollars = _score.Dollar;
        PlayerPrefs.SetString(_save.SaveKey, JsonUtility.ToJson(_save));
        _event.UpDollar -= UpdateDollarText;
        _event.UpCoin -= UpdateCoinText;

    }


#if! UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause == true) {
             _save._saveCoins = _score.Coin;
            _save._saveDollars = _score.Dollar;
            PlayerPrefs.SetString(_save.SaveKey, JsonUtility.ToJson(_save));
            _event.UpDollar -= UpdateDollarText;
            _event.UpCoin -= UpdateCoinText;
        }
    }
#endif


}

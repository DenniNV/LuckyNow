using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewScore : MonoBehaviour
{
    private Events _event = Events.getInstance();

    [SerializeField] private Text _coinText;
    [SerializeField] private Text _dollarText;

    private void Start()
    {
        _event.UpDollar += UpdateDollarText;
        _event.UpCoin += UpdateCoinText;
    }

    private void UpdateCoinText(int newCoin)
    {
        _coinText.text = "" + newCoin;
    }

    private void UpdateDollarText(int newDollar)
    {
        _dollarText.text = "" + newDollar;
    }


}

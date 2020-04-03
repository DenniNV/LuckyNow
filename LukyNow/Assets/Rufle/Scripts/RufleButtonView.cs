using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RufleButtonView : MonoBehaviour
{
    private RufleCount rufleCount = RufleCount.getInstance();
    [SerializeField]private Button _buttonFree;
    [SerializeField] private Button _buttonBuy;
    [SerializeField]private Text _buttonText;
    [SerializeField]private GameObject _panelBuy;
    [SerializeField]private int _index;
    int countClick = 0;
    public void OnClick()
    {
        if(countClick > 2)
        {
            _buttonBuy.gameObject.SetActive(false);
            _buttonFree.gameObject.SetActive(true);
            countClick = 0;
        }
        else
        {
            _buttonBuy.gameObject.SetActive(true);
            _buttonFree.gameObject.SetActive(false);
            countClick++;
        }
    }
    public void ClickFree()
    {
        rufleCount.UPCoin(_index);
    }

    public void ClickBuy()
    {
        _panelBuy.SetActive(true);
    }
}


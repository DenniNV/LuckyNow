using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaffleTicket : MonoBehaviour , IRaffleConfig
{
    private RaffleCount _raffleCount = RaffleCount.getInstance();
    private Price _price;
    [SerializeField]private BuyPanelConfig _config;
    [SerializeField]private Button _buttonFree;
    [SerializeField]private Button _buttonBuy;
    [SerializeField]private Text _buttonText;
    [SerializeField]private GameObject _panelBuy;
    [SerializeField]private GameObject _parentObject;
    [SerializeField]private int _index;
    [SerializeField]private double _ticketPrice;
    [SerializeField]private Text _winText;
    int countClick = 0;
    private void Awake()
    {
        _price = new RafflePrice(_ticketPrice);
    }
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
        _raffleCount.AddCountTickets(_index , 1);
    }
    public void ClickBuy()
    {
        if(_config == null)
        {
            _config = _panelBuy.GetComponent<BuyPanelConfig>();
        }
        _panelBuy.SetActive(true);
        _parentObject.SetActive(false);
        _config.Constructor(this);
    }
    public Text GetWinText()
    {
        return _winText;
    }

    public Price Price()
    {
        return _price;
    }

    public void UpCountTicket(int count)
    {
        _raffleCount.AddCountTickets(_index, count);
    }
}


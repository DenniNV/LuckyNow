using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPanelConfig : MonoBehaviour
{

    private BuyPanelView _buyPanelView;
    private Buy _buy;
    private TotalCountBuy _totalCount = TotalCountBuy.getInstance();
    private IRaffleConfig _config;
    private Events _events = Events.getInstance();
    private void OnEnable() 
    {
        if(_buyPanelView == null)
        {
            _buyPanelView = GetComponent<BuyPanelView>();
        }
        _events.CheckBuyButtonState += UpdateTotalPrice;
    }
    private void OnDisable()
    {
        _events.CheckBuyButtonState -= UpdateTotalPrice;
    }
    public void Constructor(IRaffleConfig config)
    {
        _config = config;
        Config();
    }
    private void Config()
    {
        _buyPanelView.WinText.text = _config.GetWinText().text;
        _buyPanelView.Price.text = _config.Price().GetPrice().ToString();
        if (_buy == null)
        {
            _buy = new Buy(_config.Price());
        }
        _totalCount.MaxCountBuy = _buy.MaxCountBuy();
    }

    public void UpdateTotalPrice()
    {
        _buyPanelView.Price.text = _totalCount.CountBuy * _config.Price().GetPrice() + "";
    } 

    public void BuyButton()
    {
        try
        {
            _buy = new Buy(new RafflePrice(_totalCount.CountBuy * _config.Price().GetPrice()));
            _buy.BuySomething();
            _config.UpCountTicket(_totalCount.CountBuy);
            gameObject.SetActive(false);
            _buyPanelView.RafflePanel.SetActive(true);
        }
        catch
        {

            gameObject.SetActive(false);
            return;
        }
        
    }

}

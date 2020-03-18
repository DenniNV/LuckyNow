using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events 
{

    private List<ButtonView> _listeners = new List<ButtonView>();
    private static Events instance;

    private Events()
    { }

    public static Events getInstance()
    {
        if (instance == null)
            instance = new Events();
        return instance;
    }

    public void CoinUpp(double coin)
    {
        UpCoin?.Invoke(coin);
    }

    public void DollarUpp(int dollar)
    {
        UpDollar?.Invoke(dollar);
    }
    public void Interactable(bool state)
    {
        ButtonState?.Invoke(state);
    }

    public void AddButtonViewObserver(ButtonView buttonView)
    {
        DedicatedState += buttonView.Dedicated;
        UnDedicatedState+= buttonView.UnDedicated;
        _listeners.Add(buttonView);
    }
    public void RemoveButtonViewObserver(ButtonView buttonView)
    {
        DedicatedState -= buttonView.Dedicated;
        UnDedicatedState -= buttonView.UnDedicated;
        _listeners.Remove(buttonView);
    }

    public void ListenerOnClick(ButtonView buttonView)
    {
        _listeners.Sort();
        int index = _listeners.BinarySearch(buttonView);
        Debug.Log(index);
        UnDedicatedState?.Invoke();
        _listeners[index].Dedicated();
    }

    

    public delegate void Coin(double coin);
    public event Coin UpCoin;
    public delegate void Dollar(int dollar);
    public event Dollar UpDollar;
    public delegate void InteractableButton( bool state );
    public event InteractableButton ButtonState;

    private delegate void DenicatedButton();
    private event DenicatedButton DedicatedState;
    private event DenicatedButton UnDedicatedState;






}

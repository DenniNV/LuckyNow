using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Events 
{

    //Down Panel
    private List<ButtonView> _listenersDownPanel = new List<ButtonView>();
    private delegate void DenicatedButton();
    private event DenicatedButton DedicatedState;
    private event DenicatedButton UnDedicatedState;
    public void AddButtonViewObserver(ButtonView buttonView)
    {
        DedicatedState += buttonView.Dedicated;
        UnDedicatedState+= buttonView.UnDedicated;
        if (buttonView != null)
        {
            _listenersDownPanel.Add(buttonView);
        }
        else
        {
            throw new Exception("In AddListenersLucky param buttonsView == null");
        }
    }
    public void RemoveButtonViewObserver(ButtonView buttonView)
    {
        DedicatedState -= buttonView.Dedicated;
        UnDedicatedState -= buttonView.UnDedicated;

        if (buttonView != null)
        {
            _listenersDownPanel.Remove(buttonView);
        }
        else
        {
            throw new Exception("In AddListenersLucky param buttonsView == null");
        }
    }

    public void ListenerOnClick(ButtonView buttonView)
    {
        _listenersDownPanel.Sort();
        int index = _listenersDownPanel.BinarySearch(buttonView);
        Debug.Log(index);
        UnDedicatedState?.Invoke();
        _listenersDownPanel[index].Dedicated();
    }


    /// <summary>
    /// /////////////////////////////////
    /// </summary>

    private List<PickerNumbersView> _pickerNumbersListeners = new List<PickerNumbersView>();
    public List<PickerNumbersView> GetPickerNumbersListerers => _pickerNumbersListeners;
    private List<PickerNumbersView> _userChoice = new List<PickerNumbersView>();
    public List<PickerNumbersView> GetUserChoice => _userChoice;
    private List<ViewWinNumbers> _randomChoice = new List<ViewWinNumbers>();
    public List<ViewWinNumbers> GetRandomChoice => _randomChoice;

    public void AddListenersPickNumberLuckyRandom(ViewWinNumbers view)
    {
        if (view != null)
        {
            _randomChoice.Add(view);
        }
        else
        {
            throw new Exception("In AddListenersPickNumberLucky param view == null");
        }
    }
    public void RemoveListenersPickNumberLuckyRundom(ViewWinNumbers view)
    {
        if (view != null)
        {
            _randomChoice.Remove(view);
        }
        else
        {
            throw new Exception("In RemoveListenersPickNumberLucky param view == null");
        }
    }

    public void AddListenersPickNumberLucky(PickerNumbersView view)
    {
        if (view != null)
        {
            _pickerNumbersListeners.Add(view);
            _userChoice.Add(view);
        }
        else
        {
            throw new Exception("In AddListenersPickNumberLucky param view == null");
        }
    }

    public void RemoveListenersPickNumberLucky(PickerNumbersView view)
    {
        if (view != null)
        {
            _pickerNumbersListeners.Remove(view);
        }
        else
        {
            throw new Exception("In RemoveListenersPickNumberLucky param view == null");
        }
    }

    public void PickedNumbersListeners(LuckyButtonsView luckyButtons)
    {
        _pickerNumbersListeners.Sort();
        _pickerNumbersListeners[0].NumberPicked.text = luckyButtons.Number.text;
        _pickerNumbersListeners[0].Dedicated();
        RemoveListenersPickNumberLucky(_pickerNumbersListeners[0]);
        OpenLastPick(_pickerNumbersListeners.Count);

    }

    private void OpenLastPick(int count)
    {
        if (count < 2)
        {
            OpenPanelLastPick?.Invoke();
            
        }
        if (count < 1)
        {
            Interactable(false);
        }
    }

    public void QuickPickNumbers(int count)
    {
        _pickerNumbersListeners.Sort();
        for (int i = 0; i < count-1; i++)
        {
            _pickerNumbersListeners[0].NumberPicked.text = UnityEngine.Random.Range(0, 59).ToString();
            _pickerNumbersListeners[0].Dedicated();
            RemoveListenersPickNumberLucky(_pickerNumbersListeners[0]);
        }
        OpenPanelLastPick?.Invoke();
    }

    public void TimeEnd()
    {
        WaitTimeEnd?.Invoke();
    }

    public void WinInLuckyNumbers(bool state)
    {
        YouWin?.Invoke(state);
    }

    public void TryAgain()
    {
        TryAgainNubmerPanel?.Invoke();
    }

    public delegate void DedicatedLuckyNumber();
    public event DedicatedLuckyNumber DedicatedLuckyState;
    public event DedicatedLuckyNumber UnDedicatedLuckyState;
    public event DedicatedLuckyNumber OpenPanelLastPick;
    public event DedicatedLuckyNumber QuickPick;
    public event DedicatedLuckyNumber WaitTimeEnd;
    public delegate void YouWinInLuckyNumbrs(bool state);
    public event YouWinInLuckyNumbrs YouWin;
    public event DedicatedLuckyNumber TryAgainNubmerPanel;

    // Single
    private Events()
    { }
    private static Events instance;
    public static Events getInstance()
    {
        if (instance == null)
            instance = new Events();
        return instance;
    }

    // Score
    public delegate void Coin(double coin);
    public event Coin UpCoin;
    public delegate void Dollar(int dollar);
    public event Dollar UpDollar;
    public void CoinUpp(double coin)
    {
        UpCoin?.Invoke(coin);
    }

    public void DollarUpp(int dollar)
    {
        UpDollar?.Invoke(dollar);
    }


    //Interactable buttons 
    public delegate void InteractableButton( bool state );
    public event InteractableButton ButtonState;
    public void Interactable(bool state)
    {
        ButtonState?.Invoke(state);
    }


}

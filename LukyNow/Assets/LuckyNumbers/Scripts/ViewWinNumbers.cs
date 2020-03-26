using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewWinNumbers : MonoBehaviour , IPickedView , IComparable
{

    [SerializeField] private Image _circle;
    [SerializeField] private Sprite _digitSelected;
    [SerializeField] private Sprite _digitUnSelected;
    [SerializeField] private Text _numberPicked;
    public int winNumber;

    public Image Circle { get => _circle; set => _circle = value; }
    public Sprite DigitSelected { get => _digitSelected; set => _digitSelected = value; }
    public Sprite DigitUnSelected { get => _digitUnSelected; set => _digitUnSelected = value; }
    public Text NumberPicked { get => _numberPicked; set => _numberPicked = value; }
    public IPickedNumbersState State { get; set; }
    public IGenerateWinNumbers GeneratorWinNumbers { set; get; }

    private Events events = Events.getInstance();

    public void Start()
    {
        events.WaitTimeEnd += WinNumber;
        events.AddListenersPickNumberLuckyRandom(this);
        events.TryAgainNubmerPanel += TryAgain;
    }
    private void OnApplicationQuit()
    {
        events.WaitTimeEnd -= WinNumber;
        events.RemoveListenersPickNumberLuckyRundom(this);
    }
    public void WinNumber()
    {
        GeneratorWinNumbers = new GenerateWinNumbers();
        _numberPicked.text = GeneratorWinNumbers.Generate().ToString();
        Dedicated();
    }

    private void TryAgain()
    {
        UnDedicated();
        events.AddListenersPickNumberLuckyRandom(this);

    }

    private void UnDedicated()
    {
        State = new UnPickerNumberSelected();
        State.UnSelected(this);
    }

    public void Dedicated()
    {
        State = new PickerNumberSelected();
        State.Selected(this);
    }

    public int CompareTo(object obj)
    {
        ViewWinNumbers b = obj as ViewWinNumbers;
        if (b != null)
        {
            return transform.position.x.GetHashCode().CompareTo(b.transform.position.x.GetHashCode());
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickerNumbersView : MonoBehaviour, IComparable , IPickedView
{

    [SerializeField] private Image _circle;
    [SerializeField] private Sprite _digitSelected;
    [SerializeField] private Sprite _digitUnSelected;
    public Image Circle { set => _circle = value; get => _circle; }
    public Sprite DigitSelected { set => _digitSelected = value; get => _digitSelected; }
    public Sprite DigitUnSelected { set => _digitUnSelected = value; get => _digitUnSelected; }
    [SerializeField] private Text _numberPicked;
    public Text NumberPicked { set => _numberPicked = value; get => _numberPicked; }
    private Events _event = Events.getInstance();
    public IPickedNumbersState State { set; get; }

    private void Start()
    {
        _event.AddListenersPickNumberLucky(this);
        _event.TryAgainNubmerPanel += TryAgain;
    }

    public void Dedicated()
    {
        State = new PickerNumberSelected();
        State.Selected(this);
    }

    public void UnDedicated()
    {
        State = new UnPickerNumberSelected();
        State.UnSelected(this);
    }

    private void OnApplicationQuit()
    {
        _event.RemoveListenersPickNumberLucky(this);
        _event.TryAgainNubmerPanel -= TryAgain;
    }

    private void TryAgain()
    {
        UnDedicated();
        _event.AddListenersPickNumberLucky(this);

    }

    public int CompareTo(object obj)
    {
        PickerNumbersView b = obj as PickerNumbersView;
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

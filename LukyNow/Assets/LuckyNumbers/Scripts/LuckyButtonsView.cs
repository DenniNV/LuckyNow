using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyButtonsView : MonoBehaviour ,IComparable
{
    [SerializeField]
    private Image _buttonImage;
    [SerializeField]
    private Button _buttonInteractable;
    public Button ButtonInteractable { set => _buttonInteractable = value; get => _buttonInteractable; }
    public Image ButtonImage { set => _buttonImage = value; get => _buttonImage; }
    [SerializeField]
    private Sprite _pickButton;
    [SerializeField]
    private Sprite _unPickButton;
    [SerializeField]
    private Text _number;
    public Text Number { get => _number; private set => _number = value; }
    public Sprite PickButton { set => _pickButton = value; get => _pickButton; }
    public Sprite UnPickButton { set => _unPickButton = value; get => _unPickButton; }


    private Events _events = Events.getInstance();

    private void Start()
    {
        _events.TryAgainNubmerPanel += UnDedicated;
    }
    public ILuckyNumbersState LuckyNumbersState { set; get; }
    public void Dedicated()
    {
        LuckyNumbersState = new DedicatedLuckyButtonState();
        LuckyNumbersState.Dedicated(this);
        _events.PickedNumbersListeners(this);
    }
    public void UnDedicated()
    {
        LuckyNumbersState = new UnDedicatedLuckyButtonState();
        LuckyNumbersState.UnDedicated(this);
    }


    public int CompareTo(object obj)
    {
        LuckyButtonsView b = obj as LuckyButtonsView;
        if (b != null)
        {
            return this._buttonImage.GetHashCode().CompareTo(b._buttonImage.GetHashCode());
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour,IComparable
{
    private Events _events = Events.getInstance();
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private Image _circle;
    [SerializeField] private Text _buttonName;
    [SerializeField] private Image _menuButton;
    [SerializeField] private Sprite[] _stateImage;

    public Text ButtonName { set => _buttonName = value; get => _buttonName; }
    public GameObject GamePanel { set =>_gamePanel = value; get => _gamePanel; }
    public Image Circle { set => _circle = value; get => _circle; }
    public Image MenuButton { set => _menuButton = value; get => _menuButton; }
    public Sprite[] State { set => _stateImage = value; get => _stateImage; }
    public IButtonState ButtonState { set; get; }

    public void Dedicated()
    {
        ButtonState = new DedicatedState();
        ButtonState.Dedicated(this);
    } 
    public void UnDedicated()
    {
        ButtonState = new UnDedicatedState();
        ButtonState.UnDedicated(this);
    }
    private void Start()
    {
        _events.AddButtonViewObserver(this);
    }
    public void OnClick()
    {
        _events.ListenerOnClick(this);
    }

    private void OnApplicationQuit()
    {
        _events.RemoveButtonViewObserver(this);
    }

    public int CompareTo(object obj)
    {
        ButtonView b = obj as ButtonView;
        if (b != null)
        {
            return this._circle.GetHashCode().CompareTo(b._circle.GetHashCode());
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }
}

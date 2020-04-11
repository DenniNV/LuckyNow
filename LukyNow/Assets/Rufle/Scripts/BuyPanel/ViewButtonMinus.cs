using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewButtonMinus : MonoBehaviour, IViewButtonPlusAndMinus
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _state;
    public IStateMinusPlusButtons State { set; get; }
    public Image Image { get => _image; set => _image = value; }
    public Sprite[] SpriteState { get => _state; set => _state = value; }
    [SerializeField] private ViewTotalCount _totalCount;
    private Events _events = Events.getInstance();
    private void OnEnable()
    {
        _events.CheckBuyButtonState += CheckState;
    }
    private void OnDisable()
    {
        _events.CheckBuyButtonState -= CheckState;
    }
    private void Start()
    {
        CheckState();
        _events.CheckBuyButtonState += CheckState;
    }

    private void CheckState()
    {
        if(TotalCountBuy.getInstance().CountBuy < 2  )
        {
            State = new MinusAndPlusUnDedicated();
            State.UnDedicated(this);
        }
        else if (TotalCountBuy.getInstance().CountBuy >1 && TotalCountBuy.getInstance().CountBuy < TotalCountBuy.getInstance().MaxCountBuy)
        {
            State = new MinusAndPlusDedicated();
            State.Dedicated(this);
        }
    }

    public void Minus()
    {
        TotalCountBuy.getInstance().CountBuy--;
        _totalCount.ShowCount(TotalCountBuy.getInstance().CountBuy);
        _events.SwitchButtonState();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour , IGetSprite 
{
    [SerializeField] private ScratchCardManager _cardManager;
    [SerializeField] private CreateBackground _createBackground;
    private Sprite _cardSprite;
    [SerializeField] private IGetSpriptableObj _cards ;
    public IGetSpriptableObj Cards => _cards;
    public Sprite GetSprite()
    {
        return _cardSprite;
    }
    public void SetMe()
    {
        _cardManager.SetSprite(this);
    }

    public void SetupSprite(IGetSpriptableObj cards)
    {
        _cards = cards;
        _cardSprite = _cards.GetSprite();
        SetMe();
        _createBackground.Create(_cards.GetPrefab());
    }

}

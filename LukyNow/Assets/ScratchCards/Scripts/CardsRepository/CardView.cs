using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour , IGetSprite 
{
    [SerializeField] private ScratchCardManager _cardManager;
    [SerializeField] private CreateBackground _createBackground;
    [SerializeField] private GameObject _cardScratchPanel;
    private Sprite _cardSprite;
    [SerializeField] private IGetCardSettings _cards;
    private Events events = Events.getInstance();
    public Sprite GetSprite()
    {
        return _cardSprite;
    }
    public void SetMe()
    {
        _cardManager.SetSprite(this);
        _cardManager.gameObject.SetActive(true);
    }

    public void SetupSprite(IGetCardSettings cards , bool state)
    {
        _cardSprite = cards.GetSprite();
        _createBackground.Create(cards.GetPrefab());
        _cardScratchPanel.SetActive(true);
        events.OpenPanelCards(state);
        SetMe();
    }

}

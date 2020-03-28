using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class CardObject : ScriptableObject 
{
    [SerializeField]
    private Sprite _sprite;
   
    public CardObject GetCard()
    {
        return this;
    }
    public Sprite GetSprite()
    {
        return _sprite;
    }
}

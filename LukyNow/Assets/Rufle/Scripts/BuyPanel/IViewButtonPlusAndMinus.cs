using UnityEngine;
using UnityEngine.UI;

public interface IViewButtonPlusAndMinus 
{
    Image Image { set; get; }
    Sprite[] SpriteState { set; get; }
    IStateMinusPlusButtons State { set; get; }

}

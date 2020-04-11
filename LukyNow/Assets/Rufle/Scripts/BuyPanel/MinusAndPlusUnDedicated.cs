using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusAndPlusUnDedicated : IStateMinusPlusButtons
{
    public void Dedicated(IViewButtonPlusAndMinus view)
    {
        view.State = new MinusAndPlusDedicated();
    }

    public void UnDedicated(IViewButtonPlusAndMinus view)
    {
        view.Image.sprite = view.SpriteState[1];
    }
}

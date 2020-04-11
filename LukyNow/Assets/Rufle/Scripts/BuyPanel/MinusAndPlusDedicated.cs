using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusAndPlusDedicated : IStateMinusPlusButtons
{
    public void Dedicated(IViewButtonPlusAndMinus view)
    {
        view.Image.sprite = view.SpriteState[0];
    }

    public void UnDedicated(IViewButtonPlusAndMinus view)
    {
        view.State = new MinusAndPlusUnDedicated();
    }
}

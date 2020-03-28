using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public interface IPickedView
{
     Image Circle { set; get; }
     Sprite DigitSelected { set; get; }
     Sprite DigitUnSelected { set; get; }
     Text NumberPicked { set; get; }
     IPickedNumbersState State { set; get; }
    void Dedicated();
}

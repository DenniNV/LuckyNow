using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerNumberSelected : IPickedNumbersState
{
    public void Selected(IPickedView numbersView )
    {
        numbersView.Circle.sprite = numbersView.DigitSelected;
    }

    public void UnSelected(IPickedView numbersView)
    {
        numbersView.State = new UnPickerNumberSelected();
    }
}

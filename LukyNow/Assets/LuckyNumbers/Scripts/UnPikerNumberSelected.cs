using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPickerNumberSelected : IPickedNumbersState
{
    public void Selected(IPickedView numbersView)
    {
        numbersView.State = new PickerNumberSelected();
    }

    public void UnSelected(IPickedView numbersView)
    {
        numbersView.Circle.sprite = numbersView.DigitUnSelected;
        numbersView.NumberPicked.text = " ";
    }
}

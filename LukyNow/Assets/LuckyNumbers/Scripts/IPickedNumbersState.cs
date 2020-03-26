using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickedNumbersState
{
    void Selected(IPickedView numbersView);
    void UnSelected(IPickedView numbersView);
}

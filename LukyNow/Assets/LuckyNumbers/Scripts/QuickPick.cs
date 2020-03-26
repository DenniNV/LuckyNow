using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickPick : MonoBehaviour
{
    Events events = Events.getInstance();

    public void OnClick()
    {
        events.QuickPickNumbers(events.GetPickerNumbersListerers.Count);
    }
}

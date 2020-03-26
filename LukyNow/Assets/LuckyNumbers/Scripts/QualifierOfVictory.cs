using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QualifierOfVictory:MonoBehaviour 
{

    private List<bool> isSameValues = new List<bool>();
    private Events _events = Events.getInstance();

    public void CompareValues()
    {
        _events.GetRandomChoice.Sort();
        _events.GetUserChoice.Sort();
        for (int i = 0; i < 5; i++)
        {
            if (_events.GetUserChoice[i].NumberPicked.text == _events.GetRandomChoice[i].NumberPicked.text)
            {
                isSameValues.Add(true);
            }
            else
            {
                continue;
            }
        }
        if (isSameValues.Count == 5)
        {
            _events.WinInLuckyNumbers(true);
        }
        else
        {
            _events.WinInLuckyNumbers(false);
        }
    }
}


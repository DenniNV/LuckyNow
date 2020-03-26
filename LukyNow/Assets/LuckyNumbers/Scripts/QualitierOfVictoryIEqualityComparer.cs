using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitierOfVictoryIEqualityComparer : IEqualityComparer<IPickedView>
{
    public bool Equals(IPickedView x, IPickedView y)
    {
        if(x.NumberPicked.text == y.NumberPicked.text)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetHashCode(IPickedView obj)
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButtonState 
{
    void Dedicated(ButtonView buttonView);
    void UnDedicated(ButtonView buttonView);
}

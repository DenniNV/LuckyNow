using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardState 
{

    void FullScratchState(IGetCardSettings card);
    void FullUnScratchState(IGetCardSettings card);

}

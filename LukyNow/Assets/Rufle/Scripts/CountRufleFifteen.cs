using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountRufleFifteen : MonoBehaviour , IRufleCount
{
    private RufleCount rufleCount = RufleCount.getInstance(); 
    public void UpCount()
    {
        rufleCount.CountTicketFiftyDollar += 1;
    }


}

using UnityEngine;
using UnityEngine.UI;
public interface IRaffleConfig 
{
    Text GetWinText();
    Price Price();

    void UpCountTicket(int count);
}

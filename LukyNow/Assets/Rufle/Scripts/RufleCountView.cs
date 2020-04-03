using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RufleCountView : MonoBehaviour
{
    private RufleCount _count = RufleCount.getInstance();
    private Events events = Events.getInstance();
    [SerializeField] private Text _firstCount;
    [SerializeField] private Text _secondCount;
    [SerializeField] private Text _threeCount;

    private void Start()
    {
        events.UpdateView += ViewCount;
        ViewCount();
    }


    public void ViewCount()
    {
        _firstCount.text = "My tickets " + _count.CountTicketOneDollar;
        _secondCount.text = "My tickets " + _count.CountTicketFiftyDollar;
        _threeCount.text = "My tickets " + _count.CountTicketHundredDollar;
    }

}

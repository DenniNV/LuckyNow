using UnityEngine;
using UnityEngine.UI;

public class BuyPanelView : MonoBehaviour
{
    [SerializeField] private Text _winText;
    [SerializeField] private Text _priseText;
    [SerializeField] private GameObject _rafflePanel;
    public GameObject RafflePanel { set => _rafflePanel = value; get => _rafflePanel; }
    public Text WinText { get => _winText; set => _winText = value; }
    public Text Price { get => _priseText; set => _priseText = value; }
   



}

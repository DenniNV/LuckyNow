using UnityEngine;
using UnityEngine.UI;

public class LastPickButton : MonoBehaviour
{
    [SerializeField]
    private Button _lookNice;
    private Events events = Events.getInstance();
    private void Awake()
    {
        events.ButtonState += Interactable;
    }
    public void Interactable(bool state)
    {
        _lookNice.interactable = !state;
    }
}

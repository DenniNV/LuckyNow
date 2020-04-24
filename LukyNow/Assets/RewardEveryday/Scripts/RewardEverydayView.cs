using System;
using UnityEngine;
using UnityEngine.UI;
public class RewardEverydayView : MonoBehaviour , IComparable
{
    #region params
    [SerializeField]
    private Text[] _everydayText;
    public Text[] EverydayText { set => _everydayText = value; get =>_everydayText; }
    [SerializeField]
    private Image _background ;
    public Image Background { set => _background = value; get => _background; }
    [SerializeField]
    private Sprite[] _sprite;
    public Sprite[] Sprite { set => _sprite = value; get=> _sprite; }
    [SerializeField]
    private Image _arrow;
    public Image Arrow { set => _arrow = value; get => _arrow; }
    public IStateRewardEveryday State { set; get; }
    #endregion
    public void CloseOrOpenText(bool state)
    {
        for (int i = 0; i < _everydayText.Length; i++)
        {
            _everydayText[i].gameObject.SetActive(state);
        }
    }
    public void Dedicated()
    {
        State = new StateEverydayRewardReceived();
        State.Received(this);
    }
    public void UnDedicated()
    {
        State = new StateEvertdayUnReceived();
        State.UnRecived(this);
    }
    public void NextRecived()
    {
        State = new StateEverydayRewardReceived();
        State.NextReceived(this);
    }
    private void Start()
    {
        TimeCounter.getInstance().AddRewardEveryday(this);
        Events.getInstance().OpenOrCloseEveryDayPanel(true);

    }
    public void OnClick()
    {
        TimeCounter.getInstance().CheckReward();
    }
    public int CompareTo(object obj)
    {
        RewardEverydayView b = obj as RewardEverydayView;
        if (b != null)
        {
            return gameObject.transform.position.x.CompareTo(b.gameObject.transform.position.x);
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }
}

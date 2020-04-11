using UnityEngine;
using UnityEngine.UI;

public class ViewTotalCount : MonoBehaviour
{
    [SerializeField]
    private Text _totalCount;


    public void ShowCount(int count)
    {
        _totalCount.text = count + "";
    }

    private void OnEnable()
    {
        ShowCount(1);
    }
}

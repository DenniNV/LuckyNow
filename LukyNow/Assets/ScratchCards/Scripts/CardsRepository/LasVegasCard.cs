using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasVegasCard : MonoBehaviour, IGetSpriptableObj
{
    [SerializeField] private CardView _cardView;
    [SerializeField] private Sprite _card;
    [SerializeField] private GameObject _prefab;

    public GameObject GetPrefab()
    {
        return _prefab;
    }

    public Sprite GetSprite()
    {
        return _card;
    }
    private void Start()
    {
        _cardView.SetupSprite(this);
    }
}

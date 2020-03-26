using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchCardCreator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _screatchCards;
    [SerializeField]
    private GameObject _parent;
    [SerializeField]

    private void Start()
    {
        GameObject card = Instantiate( _screatchCards[Random.Range(0, _screatchCards.Count)], _parent.transform.position, Quaternion.identity);
        card.transform.SetParent(_parent.transform);
    }

    



}

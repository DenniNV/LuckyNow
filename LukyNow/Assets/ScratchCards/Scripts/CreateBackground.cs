using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject _parent;
    Events events = Events.getInstance();
    List<GameObject> removeObjects = new List<GameObject>();
    private void Start()
    {
        events.RemoveObjects += ClearList;
    }
    private void ClearList()
    {
        foreach(GameObject g in removeObjects)
        {
            Destroy(g);
        }
        removeObjects.Clear();
    }

    public void Create(GameObject gameObject)
    {
       GameObject card =  Instantiate(gameObject, _parent.transform.position, Quaternion.identity);
       card.transform.SetParent(_parent.transform);
       card.transform.SetAsFirstSibling();
       card.transform.localScale = new Vector3(1, 1, 1);
       removeObjects.Add(card);
    }

  }

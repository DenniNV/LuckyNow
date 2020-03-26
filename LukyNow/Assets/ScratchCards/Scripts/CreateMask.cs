using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMask : MonoBehaviour
{
    [SerializeField]
    private GameObject _mask;
    [SerializeField]
    private GameObject _parent;

    public void CreateCard(Vector2 mousePosition)
    {
        GameObject scratch = Instantiate(_mask, mousePosition, Quaternion.identity);
        scratch.transform.SetParent(_parent.transform);
    }
}

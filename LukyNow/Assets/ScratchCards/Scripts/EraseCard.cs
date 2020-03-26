using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

class EraseCard : MonoBehaviour
{
    [SerializeField]
    CreateMask _mask;
    private bool isPressed = false;
    private void Update()
    {
        if (isPressed)
        {
            _mask.CreateCard(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
        }
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        else
        {
            if(Input.GetMouseButtonUp(0))
            {
                isPressed = false;
            }
        }
        
        

    }
}


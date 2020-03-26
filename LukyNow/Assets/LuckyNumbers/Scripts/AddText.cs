using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddText : MonoBehaviour
{
    public Button[] b;


    private void Start()
    {
        for(int i =0; i < b.Length; i++)
        {
            b[i].GetComponentInChildren<Text>().text = "" +  i;
        }
    }

}

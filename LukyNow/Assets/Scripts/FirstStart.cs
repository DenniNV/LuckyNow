using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStart : MonoBehaviour
{
    private void Start()
    {
        TimeCounter.getInstance().SaveTime();
    }
}

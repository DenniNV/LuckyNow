using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWinNumbers : IGenerateWinNumbers
{
    public int Generate()
    {
        return Random.Range(0, 59);
    }
}

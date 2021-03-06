﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetCardSettings 
{
    Sprite GetSprite();
    GameObject GetPrefab();
    void Setup();
    int WinIndex { set; get; }

    Reward GetReward();

    ICardState State { set; get; }

}

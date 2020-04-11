using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallScratch : MonoBehaviour
{
	[SerializeField]
	private EraseProgress progress;
	private void Update()
	{
		if (progress.GetCurrent >= 0.95f)
		{
			Events.getInstance().ProgressFullSmall();
		}
	}
	private void OnEnable()
	{
		Events.getInstance().ClearScratchCards += Clear;
	}
	private void OnDisable()
	{
		Events.getInstance().ClearScratchCards -= Clear;
	}
	private void Clear()
	{
		progress.Clear();
	}
}

using UnityEngine;
using UnityEngine.UI;
public class BigScratchCard : MonoBehaviour
{
	[SerializeField]
	private EraseProgress progress;
	private void Update()
	{
		if(progress.GetCurrent >= 0.95f)
		{
			Events.getInstance().ProgressFullBig();
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

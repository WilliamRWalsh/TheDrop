using System;
using UnityEngine;

public class TouchDetector : MonoBehaviour
{
	public static event Action OnTouch = delegate { };
	public static event Action OnRelease = delegate { };
	private void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
			{
				SendTouch();
			}
			else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
			{
				SendRelease();
			}
		}       
	}

	private void SendRelease()
	{
		OnRelease();
	}

	private void SendTouch()
	{
		OnTouch();
	}
}

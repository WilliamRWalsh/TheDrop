using System;
using UnityEngine;

public class BaseObjectController : MonoBehaviour
{

	[SerializeField]
	internal float maxSpeedOffsetX;
	[SerializeField]
	internal float minSpeedOffsetX;

	internal float speedX;

	[SerializeField]
	internal float maxSpeedOffsetY;
	[SerializeField]
	internal float minSpeedOffsetY;

	[SerializeField]
	internal float disableThresholdY;

	internal float speedOffsetY;

	[SerializeField]
	private bool isFlipable = false;

	internal bool isFlipped = false;

	internal float cameraSizeToXRange = 0.6f;
	internal float cameraSizeToYRange = 1.6f; 


	protected virtual void OnEnable()
	{
		/* Caveat: flip must be set before position/speed */
		if (isFlipable)
			FlipObject();

		/* Caveat: position must be set before speed */
		SetPosition();
		SetSpeeds();
	}
	protected virtual void FixedUpdate()
	{
		Move();
	}

	protected virtual void Move()
	{
		transform.Translate(speedX * Time.deltaTime, (GameStateManager.Instance.fallSpeed + speedOffsetY) * Time.deltaTime, 0);
	}

	/* This method will be overwritten for any object that doesn't start below the camera */
	protected virtual void SetPosition()
	{
		float xOffset = Camera.main.orthographicSize * cameraSizeToXRange;
		float yValue = -Camera.main.orthographicSize * cameraSizeToYRange;

		Vector3 newPosition = this.transform.position;
		newPosition.x = UnityEngine.Random.Range(-xOffset, xOffset);
		newPosition.y = yValue;

		this.transform.position = newPosition;
	}

	protected virtual void SetSpeeds()
	{
		/* Reset X & Y speeds */
		speedX = UnityEngine.Random.Range(minSpeedOffsetX, maxSpeedOffsetX); // do this w/o UnityEngine...
		speedOffsetY = UnityEngine.Random.Range(minSpeedOffsetY, maxSpeedOffsetY);
	}

	private void FlipObject()
	{
		System.Random rnd = new System.Random();
		if (rnd.NextDouble() >= 0.5)
		{
			transform.rotation = Quaternion.Euler(0, 180f, 0);
			isFlipped = true;
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
			isFlipped = false;
		}
	}
}

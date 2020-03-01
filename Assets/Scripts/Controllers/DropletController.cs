using UnityEngine;
public class DropletController : BaseObjectController
{
	private bool isFromAbove = false;

	private void LateUpdate()
	{
		if (transform.position.y > disableThresholdY)
			DropletPool.Instance.ReturnToPool(this);
		if (transform.position.y < -1 * disableThresholdY)
			DropletPool.Instance.ReturnToPool(this);
	}

	public void SetIsFromAbove(bool value)
	{
		isFromAbove = value;
	}

	protected override void SetPosition()
	{
		float xOffset = Camera.main.orthographicSize * cameraSizeToXRange;
		float yValue = -Camera.main.orthographicSize * cameraSizeToYRange;

		if (isFromAbove)
			yValue *= -1;

		Vector3 newPosition = this.transform.position;
		newPosition.x = UnityEngine.Random.Range(-xOffset, xOffset);
		newPosition.y = yValue;

		this.transform.position = newPosition;
	}
}

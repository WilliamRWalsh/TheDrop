using UnityEngine;

public class CloudController : BaseObjectController
{

	private bool isInForeground;
	private void LateUpdate()
	{
		if (transform.position.y > disableThresholdY)
			CloudPool.Instance.ReturnToPool(this);
	}

	protected override void OnEnable()
	{
		isInForeground = ProbabilityUtil.PercentChance(35f);
		SetSpeeds();
		SetScale();
		SetLayer();
		SetColor();
		SetPosition();
	}

	protected override void SetSpeeds()
	{
		base.SetSpeeds();
		if (isInForeground)
			speedOffsetY += 4;
	}

	private void SetScale()
	{
		transform.localScale = new Vector3(1, 1, 0) * 4;
		if (isInForeground)
			transform.localScale = new Vector3(1, 1, 0) * 7;
	}

	private void SetLayer()
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sortingOrder = 0;
		if (isInForeground)
			spriteRenderer.sortingOrder = 4;
	}

	private void SetColor()
	{
		GetComponent<SpriteRenderer>().color = Color.gray;
		if (isInForeground)
			GetComponent<SpriteRenderer>().color = Color.white;
	}

}

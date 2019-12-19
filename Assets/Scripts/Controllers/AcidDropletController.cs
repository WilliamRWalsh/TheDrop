public class AcidDropletController : BaseObjectController
{
	private void LateUpdate()
	{
		if (transform.position.y > disableThresholdY)
			AcidDropletPool.Instance.ReturnToPool(this);
	}
}

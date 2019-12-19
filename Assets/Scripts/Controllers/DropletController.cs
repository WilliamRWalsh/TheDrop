public class DropletController : BaseObjectController
{
	private void LateUpdate()
	{
		if (transform.position.y > disableThresholdY)
			DropletPool.Instance.ReturnToPool(this);
	}
}

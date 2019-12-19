public class BucketController : BaseObjectController
{
	private void LateUpdate()
	{
		if (transform.position.y > disableThresholdY)
			BucketPool.Instance.ReturnToPool(this);
	}
}

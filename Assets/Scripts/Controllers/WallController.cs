using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : BaseObjectController
{

	protected override void SetPosition()
	{
		Vector3 newPosition = this.transform.position;
		newPosition.x = 11;
		newPosition.y = 33;

		this.transform.position = newPosition;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private PlayerController player;

	[SerializeField]
	private int startCameraSize;

	private void LateUpdate()
	{
		if ((player.size * 2) + startCameraSize != Camera.main.orthographicSize)
		{
			//Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, (player.size * 2) + startCameraSize, Time.deltaTime * 2);

			/* Only need when player was at y=10 */
			//Vector3 newPostion = new Vector3(transform.position.x, - player.size * 1.4f, transform.position.z);
			//transform.position = Vector3.Lerp(transform.position, newPostion, Time.deltaTime * 2);
		}
	}
}

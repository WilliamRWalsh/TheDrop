using System;
using UnityEngine;

public class MenuCloudController : MonoBehaviour
{
	public static event Action OnStartReady = delegate { };
	
	private State state = State.Wait;
	private float disableThresholdY = 25;
	private float waitingY = -3.5f;
	private float startingY = 24;
	
	private enum State
	{
		Restart,
		Wait,
		Start,
	}

	private void Awake()
	{
		StartBtn.OnStart += OnStartEvent;
	}

	private void OnEnable()
	{
		if (state != State.Wait) {
			SetStartPosition();
			state = State.Restart;
		}
	}

	private void Update()
	{
		StateMachine();
	}

	private void LateUpdate()
	{
		if (transform.position.y > disableThresholdY)
			gameObject.SetActive(false);
		if (transform.position.y < -1 * disableThresholdY)
			gameObject.SetActive(false);
	}

	private void StateMachine()
	{
		switch(state)
		{
			case State.Restart:
				MoveDown();
				CheckIfInPosition();
				break;
			case State.Wait:
				break;
			case State.Start:
				MoveUp();
				break;
		}
	}

	private void MoveUp()
	{
		float baseMoveSpeed = 10f;
		transform.Translate(0, baseMoveSpeed * Time.deltaTime, 0);
	}

	private void MoveDown()
	{
		float baseMoveSpeed = -10f;
		transform.Translate(0, baseMoveSpeed * Time.deltaTime, 0);
	}

	private void CheckIfInPosition()
	{
		if (transform.position.y < waitingY) {
			/* Set position */
			transform.position = new Vector2(0, waitingY);
			/* Set State */
			state = State.Wait;
			/* Send Start Ready Event */
			OnStartReady();
		}
	}

	private void SetStartPosition()
	{
		transform.position = new Vector2(0, startingY);
	}

	#region Event Handlers
	private void OnStartEvent()
	{
		state = State.Start;
	}
	#endregion

}

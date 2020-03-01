using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
	/* Private Vars */
	[SerializeField]
	private PlayerController player;

	private int score = 0;
	private float runningTimer = 0;
	private float scoreUpdatedAt = 0;

	private enum State
	{
		Wait,
		Running,
	}

	private int state = (int)State.Wait;


	private void Awake()
	{
		/* Events to listen to */
		StartBtn.OnStart += GameStarting;
		PlayerController.OnDeath += GameEnding;
		RestartBtn.OnRestart += RestartScore;
	}

	/* Event Handling */
	#region Event Handling Methods
	private void GameStarting()
	{
		state = (int)State.Running;
	}

	private void GameEnding()
	{
		state = (int)State.Wait;
	}

	private void RestartScore()
	{
		score = 0;
		UpdateScoreUI(0);
	}
	#endregion

	private void Update()
	{
		StateMachine();
	}

	private void StateMachine()
	{
		switch (state)
		{
			case (int)State.Wait:
				/* Do nothing */
				break;
			case (int)State.Running:
				GameRunning();
				break;
		}
	}


	private void GameRunning()
	{
		runningTimer += Time.deltaTime;
		if (Mathf.FloorToInt(runningTimer) - Mathf.FloorToInt(scoreUpdatedAt) > 0)
			CalculateNewScore(runningTimer);
	}

	private void CalculateNewScore(float updatedTime)
	{
		if (player == null) return;

		score += 10 * (player.size + 1) / 10;
		UpdateScoreUI(updatedTime);
	}

	private void UpdateScoreUI(float updatedTime)
	{
		TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
		textMeshPro.text = score.ToString();
		scoreUpdatedAt = updatedTime;
	}

}





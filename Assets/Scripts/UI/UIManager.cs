using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	private void Awake()
	{
		PlayerController.OnDeath += OnDeathEvent;
		// RestartBtn.OnRestart += RestartGameEvent;
		MenuCloudController.OnStartReady += StartReadyEvent;
	}

	private void OnDeathEvent()
	{
		GetComponentInChildren<RestartBtn>(true).gameObject.SetActive(true);
	}

	private void StartReadyEvent()
	{
		GetComponentInChildren<StartBtn>(true).gameObject.SetActive(true);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	private void Awake()
	{
		GameStateManager.OnEndGame += ShowRestart;
	}

	private void ShowRestart()
	{
		GetComponentInChildren<RestartBtn>(true).gameObject.SetActive(true);
		
	}
}

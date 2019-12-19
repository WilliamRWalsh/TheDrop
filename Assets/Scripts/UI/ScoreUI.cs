using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{ 
	private void Awake()
	{
		GameStateManager.OnScoreUpdate += ScoreUpdate;

	}

	private void ScoreUpdate(int score)
	{
		Debug.Log(score);
		TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
		textMeshPro.text = score.ToString();
	}

}

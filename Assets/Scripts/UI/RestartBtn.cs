using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RestartBtn : MonoBehaviour
{
	public static event Action OnRestart = delegate { };

	public void ButtonedPressed() {
		OnRestart();
		this.gameObject.SetActive(false);
	}
}

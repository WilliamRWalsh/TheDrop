using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
	private static GameStateManager _instance;

	public static GameStateManager Instance { get { return _instance; } }

	public float fallSpeed { get; private set; }

	public float timer { get; private set; }
	public int score { get; private set; }

	[SerializeField]
	private PlayerController player;

	public static event Action<int> OnScoreUpdate = delegate { };
	public static event Action OnEndGame = delegate { };
	public static event Action OnStartGame = delegate { };


	private float scoreUpdatedAt;
	private bool isInGame = false;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}

		PlayerController.OnDeath += EndGame;
		RestartBtn.OnRestart += StartGame;
		TouchDetector.OnTouch += Touch;
		TouchDetector.OnRelease += Release;

		fallSpeed = 8;
	}

	private void Start()
	{
		StartGame();
	}

	private void Update()
	{
		if (isInGame)
			InGame();
	}

	private void InGame()
	{
		timer += Time.deltaTime;
		/* There has to be a better way to determine when to update the score */
		if (Mathf.FloorToInt(timer) - Mathf.FloorToInt(scoreUpdatedAt) > 0)
			UpdateScore();
	}

	private void UpdateScore()
	{
		scoreUpdatedAt = timer;
		score += 10 * (player.size+1)/10;
		OnScoreUpdate(score);
		
	}

	private void StartGame()
	{
		score = 0;
		scoreUpdatedAt = 0;
		OnScoreUpdate(0);
		timer = 0;
		isInGame = true;
		player.gameObject.SetActive(true);
		OnStartGame();
	}

	private void EndGame()
	{
		isInGame = false;
		OnEndGame();
	}

	private void Touch()
	{
		fallSpeed = 10;
	}

	private void Release()
	{
		fallSpeed = 8;
	}

}





/* Speeding up code I might use later for wind or some other boost*/

//private bool isSpeedingUp = true;

//[SerializeField]
//private float maxFallSpeed;
//[SerializeField]
//private float minFallSpeed;
//[SerializeField]
//private float responseSpeedUp;
//[SerializeField]
//private float responseSpeedDown;

//public void ToggleSpeedUp()
//{
//	isSpeedingUp = isSpeedingUp ? false : true;
//}

//private void LateUpdate()
//{
//	//CheckSpeedUp();
//}

//private void CheckSpeedUp()
//{
//	if (isSpeedingUp && fallSpeed != maxFallSpeed)
//	{
//		fallSpeed = Mathf.Lerp(fallSpeed, maxFallSpeed, responseSpeedUp * Time.deltaTime);
//	}
//	else if (!isSpeedingUp && fallSpeed != minFallSpeed)
//	{
//		fallSpeed = Mathf.Lerp(fallSpeed, minFallSpeed, responseSpeedDown * Time.deltaTime);
//	}
//} 
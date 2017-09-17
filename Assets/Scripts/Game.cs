using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

	public Text gameOverMessage;
	public float babyDeadDelay;
	public float gameOverDelay;
	private bool _isGameOver;

	private void OnEnable()
	{
		Poop.PoopExploded += PoopExploded;
		BabyBehavior.Died += BabyDied;
	}

	private void OnDisable()
	{
		Poop.PoopExploded -= PoopExploded;
		BabyBehavior.Died -= BabyDied;
	}

	private void PoopExploded()
	{
		StartCoroutine(GameOver("you let your baby's poop explode"));
	}

	private void BabyDied(string msg)
	{
		StartCoroutine(GameOver(msg));
	}

	private IEnumerator GameOver(string msg)
	{
		if (_isGameOver) yield break;
		_isGameOver = true;
		yield return new WaitForSeconds(babyDeadDelay);
		gameOverMessage.gameObject.SetActive(true);
		gameOverMessage.text = msg;
		yield return new WaitForSeconds(gameOverDelay);
		SceneManager.LoadScene(0);
	}


}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject targetss;
	public Vector3 spawnValues;
	public int targetsCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GameObject spawnEffect;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;
	public GUIText hpText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameoverText.text = "";
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	void Update() {
		if(restart){
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i = 0; i < targetsCount; i++){
				Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(targetss, spawnPos, spawnRotation);
				Instantiate(spawnEffect, spawnPos, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver) {
				restartText.text = "Press 'R' to restart the game";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore(){
		scoreText.text = "" + score;
	}

	public void GameOver() {
		gameoverText.text = "Game Over!";
		gameOver = true;
	}
}
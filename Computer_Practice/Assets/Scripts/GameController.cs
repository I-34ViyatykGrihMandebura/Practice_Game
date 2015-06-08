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
	private bool win;
	private int score;
	public int hp;
	public int curHp;

	void Start () {
		Cursor.visible = true;
		gameOver = false;
		restart = false;
		win = false;
		restartText.text = "";
		gameoverText.text = "";
		hpText.text = "";
		hp = 4;
		score = 0;
		UpdateScore();
		Updatehp();
		StartCoroutine(SpawnWaves());
	}

	void Update() {
		curHp = 0;
		if(hp <= 0){
			hp = curHp;
			hpText.text = "" + curHp;
		}
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
			else 
			if(win){
				win = true;
				restart = false;
				break;
			}
			Application.LoadLevel(Random.Range(1, Application.levelCount - 1));
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
		Cursor.visible = false;
	}

	public void hpManager(int damageToGive){
		hp -= damageToGive;
		Updatehp();
	}

	void Updatehp(){
		hpText.text = "" + hp;
	}

	public void WinnigTheGame(){
		if(score >= 10){
			win = true;
		}
	}
}
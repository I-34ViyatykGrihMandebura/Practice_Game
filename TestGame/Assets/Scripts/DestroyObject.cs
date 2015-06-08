using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	
	public GameController gameController;
	public int damageToGive;
	public int pointsReset;
	
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null){
			Debug.Log("Cannot find 'GameController' scrip!");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "CoinsToPick"){
			gameController.AddScore(-pointsReset);
		}
	}
}

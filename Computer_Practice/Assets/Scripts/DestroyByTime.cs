using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifeTime;
	public int pointToAdd;
	public GameObject death;
	public int scoreValue;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null){
			Debug.Log("Cannot find 'GameController' scrip!");
		}
		Destroy(gameObject, lifeTime);
	}

	void OnMouseDown(){
		gameController.AddScore(scoreValue);
		Vector3 deathPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Quaternion deathRotation = Quaternion.identity;
		Instantiate(death, deathPos, deathRotation);
		Destroy(gameObject);
	}
}

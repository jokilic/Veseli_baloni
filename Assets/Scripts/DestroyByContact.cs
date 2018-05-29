using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject poof;
	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();
		
		if(gameController == null)
			Debug.Log("Cannot find 'GameController' script");
	}

	void OnMouseDown()
	{
		Instantiate (poof, transform.position, transform.rotation);
		gameController.AddScore (scoreValue);
		Destroy (gameObject);
	}
}

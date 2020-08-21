using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactBomb : MonoBehaviour
{
    public GameObject poof;
	private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();
		
		if(gameController == null)
			Debug.Log("Cannot find 'GameController' script");
    }

   void OnMouseDown() {
		gameController.sound.PlayOneShot(gameController.bombSound, 1);
		Instantiate (poof, transform.position, transform.rotation);
		gameController.GameOver();
		Destroy (gameObject);
	}
}

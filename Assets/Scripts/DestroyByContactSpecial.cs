using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactSpecial : MonoBehaviour
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
		gameController.sound.PlayOneShot(gameController.specialSound, 1);
		Instantiate (poof, transform.position, transform.rotation);
		gameController.AddScore (scoreValue);
		Destroy (gameObject);
	}
}

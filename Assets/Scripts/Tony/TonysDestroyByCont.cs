using UnityEngine;
using System.Collections;

public class TonysDestroyByCont : MonoBehaviour
{
	public GameObject poof;
	public int poppedValue;
	private TonysGameCont gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<TonysGameCont> ();

		if(gameController == null)
			Debug.Log("Cannot find 'GameController' script");
	}

	void OnMouseDown()
	{
		Instantiate (poof, transform.position, transform.rotation);
		gameController.AddScore (poppedValue);
		Destroy (gameObject);
	}
}

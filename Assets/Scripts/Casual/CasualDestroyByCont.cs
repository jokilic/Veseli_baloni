using UnityEngine;
using System.Collections;

public class CasualDestroyByCont : MonoBehaviour
{
	public GameObject poof;
	public int poppedValue;
	private CasualGameCont gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<CasualGameCont> ();

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

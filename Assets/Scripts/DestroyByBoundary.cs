using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
	public GameController gameController;
	public int missedBallons;
	private int missed = 0;
	public GUIText missedText;


	void OnTriggerExit(Collider other)
	{	
		if(other.gameObject.tag == "Baloon") {
			missed++;
			Destroy (other.gameObject);
			if (missed == missedBallons)
				gameController.GameOver();
		}
	}

	void Update()
	{
		missedText.text = "Missed:" + missed;
	}
}

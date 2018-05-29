using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    Vector3 pozicija;
	public GameController speedUp;

	void Start ()
	{
		speedUp = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

    void Update ()
    {
        pozicija = transform.position;
        pozicija.z += speedUp.speed;
        transform.position = pozicija;
    }
}

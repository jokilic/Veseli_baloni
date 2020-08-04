using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpecial : MonoBehaviour
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
        pozicija.z += speedUp.specialSpeed;
        transform.position = pozicija;
    }
}

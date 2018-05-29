using UnityEngine;
using System.Collections;

public class CasualMover : MonoBehaviour
{
    Vector3 pozicija;
    public CasualGameCont speedUp;

    void Start ()
    {
        speedUp = GameObject.Find("GameController").GetComponent<CasualGameCont>();
    }

	void Update ()
    {
        pozicija = transform.position;
        pozicija.z += speedUp.speed;
        transform.position = pozicija;
    }
}

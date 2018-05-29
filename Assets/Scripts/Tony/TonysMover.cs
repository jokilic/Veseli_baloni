using UnityEngine;
using System.Collections;

public class TonysMover : MonoBehaviour
{
    Vector3 pozicija;
    public TonysGameCont speedUp;

    void Start()
    {
        speedUp = GameObject.Find("GameController").GetComponent<TonysGameCont>();
    }

    void Update()
    {
        pozicija = transform.position;
        pozicija.z += speedUp.speed;
        transform.position = pozicija;
    }
}

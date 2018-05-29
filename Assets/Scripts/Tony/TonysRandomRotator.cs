using UnityEngine;
using System.Collections;

public class TonysRandomRotator : MonoBehaviour
{

    private float speed;

    void Start ()
    {
        speed = Random.Range(-1.5f, 1.5f);
    }

	void Update ()
    {
        transform.Rotate(0, 0, speed);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TonyBackToPlay : MonoBehaviour
{
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("Play");
        }
    }
}

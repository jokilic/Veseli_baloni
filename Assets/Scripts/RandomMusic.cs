using UnityEngine;
using System.Collections;

public class RandomMusic : MonoBehaviour
{
	public AudioClip[] pjesme;
	private AudioSource audioSource;

	void Start ()
	{
		
		audioSource = GetComponent<AudioSource> ();
	}

	private AudioClip GetRandomSong()
	{
		return pjesme [Random.Range (0, pjesme.Length)];
	}

	void Update ()
	{
		if (!GetComponent<AudioSource>().isPlaying)
		{
			audioSource.clip = GetRandomSong ();
			audioSource.Play ();
		}
	}
}

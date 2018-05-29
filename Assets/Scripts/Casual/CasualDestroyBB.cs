﻿using UnityEngine;
using System.Collections;

public class CasualDestroyBB : MonoBehaviour
{
	private int missed = 0;
	public GUIText missedText;

	void OnTriggerExit(Collider other)
	{
		missed++;
		Destroy (other.gameObject);
	}

	void Update()
	{
		missedText.text = "Missed:" + missed;
	}
}

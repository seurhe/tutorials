﻿using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour 
{
	public float fadeSpeed = 2f;
	public float highIntensity = 2f;
	public float lowIntensity = 0.5f;
	public float changeMargin = 0.2f;
	public bool alarmOn;

	private float targetIntenity;

	void Awake()
	{
		light.intensity = 0f;
		targetIntenity = highIntensity;
	}

	void Update()
	{
		if (alarmOn) {
			light.intensity = Mathf.Lerp (light.intensity, targetIntenity, fadeSpeed * Time.deltaTime);
			CheckTargetIntensity ();
		} else {
			light.intensity = Mathf.Lerp(light.intensity, 0f, fadeSpeed * Time.deltaTime);
		}
	}

	void CheckTargetIntensity()
	{
		if (Mathf.Abs (targetIntenity - light.intensity) < changeMargin) {
			if (targetIntenity == highIntensity)
			{
				targetIntenity = lowIntensity;
			} else 
			{
				targetIntenity = highIntensity;
			}
		}
	}
}

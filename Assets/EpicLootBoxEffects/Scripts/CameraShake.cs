using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour 
{
	public float shakeTimer;
	public float shakeAmount;
	private Vector3 startPos;
	public static CameraShake MyCameraShake;

	private void Awake () 
	{
		MyCameraShake = this;
		startPos = transform.position;
	}

	private void Update () 
	{
		if (shakeTimer >= 0) 
		{
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			Transform transform1 = transform;
			Vector3 position = transform1.position; 
			position = new Vector3 (position.x + (shakePos.x * 0.3f), position.y + shakePos.y, position.z);
			transform1.position = position;
			shakeTimer -= Time.deltaTime;
		}
		else 
		{
			transform.position = startPos;
		}
	}

	public void ShakeCamera (float shakePwr, float shakeDur) 
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
	}
}
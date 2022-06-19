using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public GameObject openTarget;
	private bool isOpen = false;
	private Vector3 closePos;
	private Coroutine cor;
	public bool isDied = false;

	private void Start()
	{
		closePos = transform.position;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag is "Player" or "Enemy" && transform.position == closePos)
		{
			isOpen = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && transform.position == closePos)
			isOpen = true;
	}

	private void FixedUpdate()
	{
		if (!isOpen) return;
		Vector3 posTo = openTarget.transform.position;
		Vector3 smoothPos = Vector3.Lerp(transform.position, posTo, 0.1f);
		transform.position = smoothPos;
		if (transform.position == posTo)
		{
			Debug.Log("Lol");
			isOpen = false;
			if (cor != null) StopCoroutine(cor);
			cor  = StartCoroutine(CloseDoor());
		}
	}

	private IEnumerator CloseDoor()
	{
		while (transform.position != closePos)
		{
			yield return new WaitForFixedUpdate();
			Vector3 smoothPos = Vector3.Lerp(transform.position, closePos, 0.1f);
			transform.position = smoothPos;
		}
		isOpen = false;
	}

	public void Dead()
	{
		isDied = true;
		enabled = false;
	}
}

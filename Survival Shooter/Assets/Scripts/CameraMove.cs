using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform playerTransform;
	public float smoothing;

	private Vector3 offset;

	void Awake(){
		offset = transform.position - playerTransform.position;
	}

	void FixedUpdate(){
		Vector3 newCameraPos = playerTransform.position + offset;
		transform.position = Vector3.Lerp (transform.position, newCameraPos, smoothing * Time.deltaTime);
	}
}

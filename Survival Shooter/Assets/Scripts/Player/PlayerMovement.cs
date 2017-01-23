using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
	public float cameraMaxDistance;

	private int floorMask;
	private Rigidbody playerRigidbody;
	private Vector3 movement;
	private Animator anim;

	void Awake(){
		playerRigidbody = GetComponent<Rigidbody> ();
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		float horizontalMove = Input.GetAxisRaw ("Horizontal");
		float verticalMove = Input.GetAxisRaw ("Vertical");
		Moving (horizontalMove, verticalMove);
		Turning ();
		Animating (horizontalMove, verticalMove);
	}

	void Moving(float horizontalMove, float verticalMove){
		movement.Set (horizontalMove, 0.0f, verticalMove);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning(){
		Ray cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit cameraHit;
		if (Physics.Raycast (cameraRay, out cameraHit, cameraMaxDistance, floorMask)) {
			Vector3 playerToMouse = cameraHit.point - transform.position;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating(float horizontalMove, float verticalMove){
		bool walking = horizontalMove != 0f || verticalMove != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}

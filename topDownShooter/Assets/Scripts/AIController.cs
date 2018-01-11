
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
	//References
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	//Handling
	public float Recoil = 1f;
	public float ReloadSpeed = 1f;
	public float bulletVelocity = 6f;
	public float bulletDuration = 2f;
	public float BackwardsVelocity = 2f;
	public float ForwardsVelocity = 6f;
	public float SidewaysVelocity = 4f;
    public float rotationSpeed = 1f;
    public float stopDistance = 1f;


	//Local Variables
	private Quaternion targetRotation; 
	private float TimeStamp;
	private float speed = 5f;

	void Fire(){
		var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = bulletSpawn.transform.forward * bulletVelocity;

		Destroy (bullet, bulletDuration);
		//When it's time to start firing again
		TimeStamp = Time.time + ReloadSpeed;
	}

		
	// Update is called once per frame
	void Update () {

		Vector3 movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - (transform.position);
		difference.Normalize ();
		targetRotation = Quaternion.LookRotation (difference);
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		Vector3 motion = movement.normalized;



		//Determines if the player is moving backwards, sideways or forwards
		if (Vector3.Dot(transform.forward, motion) > .4)
		{
			speed = ForwardsVelocity;
		}
		else if(Vector3.Dot(transform.forward, motion) < -.6)
		{
			speed = BackwardsVelocity;
		}
		else
		{
			speed = SidewaysVelocity;
		}


	}
}

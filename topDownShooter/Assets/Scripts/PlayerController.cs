using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (CharacterController))]


public class PlayerController : MonoBehaviour {

	//References
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	//Handling
	public float rotationSpeed = 450f;
	private float speed = 5f;
	public float bulletVelocity = 6f;
	public float bulletDuration = 2f;
    public float BackwardsVelocity = 2f;
    public float ForwardsVelocity = 6f;
    public float SidewaysVelocity = 4f;
    
	//System Variables
	private Quaternion targetRotation; private CharacterController controller;

	void Fire(){
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);
		
			bullet.GetComponent<Rigidbody> ().velocity = bulletSpawn.transform.forward * bulletVelocity;

		Destroy (bullet, bulletDuration);
	}
	// Use this for initialization
	void Start () {

 controller = GetComponent<CharacterController>();	}
	

	void FixedUpdate () {
		Vector3 movement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));



		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - (transform.position);
		difference.Normalize ();
		targetRotation = Quaternion.LookRotation (difference);
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

			
		Vector3 motion = movement.normalized;

        //Debug.Log(Vector3.Dot( transform.forward, motion));
        //Debug.Log(motion);
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
        controller.Move(motion * Time.deltaTime * speed);
        Debug.Log(speed);
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Fire ();
		}
	}
}

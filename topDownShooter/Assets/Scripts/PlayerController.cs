using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent (typeof (CharacterController))]


public class PlayerController : MonoBehaviour {

	//Reference

	public RawImage CoolDown;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	//Handling
	public float Recoil = 1f;
	public float ReloadSpeed = 1f;
	public float rotationSpeed = 450f;
	private float speed = 5f;
	public float bulletVelocity = 6f;
	public float bulletDuration = 2f;
    public float BackwardsVelocity = 2f;
    public float ForwardsVelocity = 6f;
    public float SidewaysVelocity = 4f;
	private float TimeStamp;
    
	//System Variables
	private Quaternion targetRotation; private CharacterController controller;

	void Fire(){
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);
		
			bullet.GetComponent<Rigidbody> ().velocity = bulletSpawn.transform.forward * bulletVelocity;


		 

		Destroy (bullet, bulletDuration);
		CoolDown.texture = Resources.Load ("10_Empty") as Texture;
		TimeStamp = Time.time + ReloadSpeed;
	}
	// Use this for initialization
	void Start () {

		 

		controller = GetComponent<CharacterController>();TimeStamp = Time.time;	}


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
        
		//Debug.Log(speed);
		//Debug.Log (-(TimeStamp - Time.time)/ReloadSpeed);

		if ((Input.GetKeyDown (KeyCode.Mouse0)) && (Time.time >= TimeStamp)) {
			Fire ();
			controller.Move((transform.forward * -1) * Recoil);
		
		
		}


		float TimeCalc = (TimeStamp - Time.time) * ReloadSpeed;

			




		if ((TimeCalc) > 0.9) {
			CoolDown.texture = Resources.Load ("10_Empty") as Texture;
		}
		else if((TimeCalc ) >0.8) {

			CoolDown.texture = Resources.Load ("9") as Texture;
		}
		else if((TimeCalc) > 0.7) {
			CoolDown.texture = Resources.Load ("8") as Texture;
		}
		else if((TimeCalc) > 0.6) {
			CoolDown.texture = Resources.Load ("7") as Texture;
		}
		else if((TimeCalc) > 0.5) {
			CoolDown.texture = Resources.Load ("6") as Texture;
		}
		else if((TimeCalc) > 0.4) {
			CoolDown.texture = Resources.Load ("5") as Texture;
		}
		else if((TimeCalc) > 0.3) {
			CoolDown.texture = Resources.Load ("4") as Texture;
		}
		else if((TimeCalc) > 0.2 ) {
			CoolDown.texture = Resources.Load ("3") as Texture;
		}
		else if((TimeCalc) > 0.1) {
			CoolDown.texture = Resources.Load ("2") as Texture;
		}
		else {
			CoolDown.texture = Resources.Load ("1_Full") as Texture;
		}
	
		


	}
}

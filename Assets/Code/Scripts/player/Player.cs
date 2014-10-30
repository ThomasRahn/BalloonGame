using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float sensitivityX = 15.0f;
	public float sensitivityY = 15.0f;
	public Quaternion originalRotation;

	public float rotationX;
	public float rotationY;

	public GameObject bullet;
	void Start () {
		originalRotation = this.transform.rotation;
		rotationX = 0;
		rotationY = 0;
	}
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.W)){
			transform.Translate (Vector3.forward * 5.0f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate (-Vector3.forward * 5.0f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate (-Vector3.right * 5.0f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate (Vector3.right * 5.0f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftShift)){
			transform.Translate (-Vector3.up * 5.0f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.Space)){
			transform.Translate (Vector3.up * 5.0f * Time.deltaTime);
		}


		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
		
		transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		
		if(Input.GetKey(KeyCode.LeftControl) || Input.GetButton("Fire1")){
			Shoot ();
		}

	}


	public void Shoot(){
		if(bullet != null){
			GameObject shoot = Instantiate(bullet,this.transform.position, Quaternion.identity) as GameObject;
			shoot.rigidbody.velocity = transform.forward * 10.0f;
			Destroy(shoot, 1.5f);
		}
	}
}

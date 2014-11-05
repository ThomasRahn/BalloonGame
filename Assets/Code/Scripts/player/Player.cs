using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float sensitivityX = 15.0f;
	public float sensitivityY = 15.0f;
	public Quaternion originalRotation;

	public float minX = -360;
	public float maxX = 360;
	public float minY = -60;
	public float maxY = 60;

	public float speed = 500.0f;
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

		
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		
		
		rotationX = Mathf.Clamp(rotationX,minX,maxX);
		rotationY = Mathf.Clamp(rotationY,minY,maxY);
		
		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
		
		transform.localRotation = originalRotation * xQuaternion * yQuaternion;

		if(Input.GetKey(KeyCode.W)){
			transform.rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.rigidbody.AddForce(-transform.forward * speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.rigidbody.AddForce(-transform.right * speed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.rigidbody.AddForce(transform.right * speed * Time.deltaTime);
		}


		if(Input.GetButtonDown("Fire1")){
			GameObject shoot = Instantiate(bullet,Camera.main.transform.position,Quaternion.identity) as GameObject;
			shoot.rigidbody.velocity = transform.forward * 5.0f;
			shoot.transform.rotation = transform.rotation;
			shoot.transform.Rotate(new Vector3(90,0,0));
			Destroy(shoot,1.0f);
		}
		Debug.Log (transform.forward);
		
	}
	
	
	
}

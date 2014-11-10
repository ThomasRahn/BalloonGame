using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float sensitivityX = 15.0f;
	public float sensitivityY = 15.0f;
	public Quaternion originalRotation;
	
	public float minY = -60;
	public float maxY = 60;

	public float speed = 500.0f;
	public float rotationX;
	public float rotationY;

	public float lockonTime = 2.0f;
	public float maxLockDistance = 5000.0f;

	public GameObject locked;
	public GameObject lockOnObject;
	public GameObject bullet;
	public GameObject missle;
	private GameObject text;

	void Start () {
		originalRotation = this.transform.rotation;
		rotationX = 0;
		rotationY = 0;
		text = GameObject.FindGameObjectWithTag("locked");
		text.guiText.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		Movement ();
		Shooting ();

		LockOn ();
		if(locked != null){
			GameObject text = GameObject.FindGameObjectWithTag("locked");
			if(!text.guiText.enabled){
				text.guiText.enabled = true;
				StartCoroutine(HideText());
			}
			if(Input.GetKeyDown(KeyCode.T)){
				Vector3 left = GameObject.FindGameObjectWithTag("leftMissle").transform.position;
				Vector3 right = GameObject.FindGameObjectWithTag("rightMissle").transform.position;

				//Left
				GameObject mis1 = Instantiate(missle,left,transform.rotation) as GameObject;
				mis1.transform.position = left;
				Vector3 velo = locked.transform.position - mis1.transform.position;
				mis1.rigidbody.velocity = velo * 10.0f;

				//Right
				GameObject mis2 = Instantiate(missle,right,transform.rotation) as GameObject;
				mis2.transform.position = right;
				velo = (locked.transform.position - mis2.transform.position);
				mis2.rigidbody.velocity = velo * 10.0f;

			}
		}
	}

	IEnumerator HideText(){
		yield return new WaitForSeconds (4);
		text.guiText.enabled = false;
		locked = null;
	}
	void LockOn(){
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
			if(hit.distance < maxLockDistance){
				GameObject obj = hit.collider.gameObject;
				if(lockOnObject == null){
					lockOnObject = obj;
				}
				if( lockOnObject == obj){
					lockonTime -= Time.deltaTime;
					if(lockonTime <= 0.0f){
						locked = obj;
						lockonTime = 2.0f;
					}
				}else{
					lockonTime = 2.0f;
				}
			}else{
				lockonTime = 2.0f;
			}
		}
	}
	void Movement(){
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		
		
		//	rotationX = Mathf.Clamp(rotationX,minX,maxX);
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
		
		


	}
	void Shooting(){
		if(Input.GetButtonDown("Fire1")){
			GameObject shoot = Instantiate(bullet,Camera.main.transform.position,Quaternion.identity) as GameObject;
			shoot.rigidbody.velocity = transform.rigidbody.velocity + (transform.forward *5.0f);
			//shoot.rigidbody.AddForce (transform.forward * 5.0f);
			shoot.transform.rotation = transform.rotation;
			shoot.transform.Rotate(new Vector3(90,0,0));
			Destroy(shoot,4.0f);
		}
	}
	
	
}

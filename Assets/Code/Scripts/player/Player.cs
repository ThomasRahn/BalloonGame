using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public float invinsibility = 2.0f;

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
		if(!GameController.gameOver && ! GameController.dead){
			Movement ();
			Shooting ();

			Zoom();

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
					velo.y +=5.0f;
					mis1.rigidbody.velocity = velo * 3.0f;

					//Right
					GameObject mis2 = Instantiate(missle,right,transform.rotation) as GameObject;
					mis2.transform.position = right;
					velo = (locked.transform.position - mis2.transform.position);
					velo.y +=5.0f;
					mis2.rigidbody.velocity = velo * 3.0f;

				}
			}
			if(invinsibility > 0.0f){
				invinsibility -= Time.deltaTime;
			}

		}
	}



	IEnumerator HideText(){
		yield return new WaitForSeconds (2);
		text.guiText.enabled = false;
		locked = null;
	}


	void LockOn(){
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
			if(hit.distance < maxLockDistance && hit.transform.gameObject.tag == "enemy"){
				GameObject obj = hit.collider.gameObject;
				if(lockOnObject == null){
					lockOnObject = obj;
					return;
				}
				if( lockOnObject == obj){
					lockonTime -= Time.deltaTime;
					if(lockonTime <= 0.0f){
						locked = obj;
						lockonTime = 2.0f;
						return;
					}
				}else{
					lockonTime = 2.0f;
				}
			}else{
				lockonTime = 2.0f;
			}
		}
	}
	void Zoom(){
		if(Input.GetKey(KeyCode.Mouse1)){
			Camera.main.fieldOfView = 40;
		}else{
			Camera.main.fieldOfView = 60;
		}
	}

	//This is for custom movement
	void Movement(){
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

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

	//Shoot if button press
	void Shooting(){
		if(Input.GetButtonDown("Fire1")){
			GameObject shoot = Instantiate(bullet) as GameObject;
			shoot.transform.position = GameObject.FindGameObjectWithTag("gunTip").transform.position;
			shoot.rigidbody.velocity = this.transform.forward * 60.0f;
			shoot.transform.rotation = transform.rotation;
			shoot.transform.Rotate(new Vector3(0,90,0));
			Destroy(shoot,2.5f);
		}
	}

	public void Die(){
		invinsibility = 5.0f;
		GameController.Die ();
		Destroy (this.GetComponent<Wrap> ());
		this.rigidbody.useGravity = true;
		StartCoroutine (Spawn ());
	}

	//spawn the player back at 0,0,0
	IEnumerator Spawn(){
		yield return new WaitForSeconds (4);
		this.transform.position = new Vector3 (0, 0, 0);
		this.rigidbody.useGravity = false;
		this.gameObject.AddComponent<Wrap> ();
	}

	//If the player collides with balloon or enemy, die and pop the object.
	void OnCollisionEnter(Collision col){
		GameObject obj = col.gameObject;
		if(invinsibility <= 0.0f ){
			if(obj.CompareTag("balloon")){
				Destroy (obj);
				ClusterController.BalloonPoped(obj);
				GameController.UpdateScore(1);
				Die ();
			}
			if(obj.CompareTag("enemy")){
				Destroy (obj);
				ClusterController.KillEnemy();
				GameController.UpdateScore(10);
				Die ();
			}
			Debug.Log(obj.tag);
			if(obj.CompareTag("enemyBullet")){
				Destroy (obj);
				Die ();
			}

		}
	}
}

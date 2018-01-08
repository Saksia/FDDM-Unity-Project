using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipControl : MonoBehaviour {
    public float speed;
    public GameObject projectile;

    float left, rigth, up, down;

    public VirtualJoystick joystick;

	// Use this for initialization
	void Start () {
        left = Camera.main.ViewportToWorldPoint(new Vector3(0,0)).x;
        rigth = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).x;
        up = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).y;
        down = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).y;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Fire();
    }

    private void Move()
    {
        //float hMov = Input.GetAxis("Horizontal");
        //float vMov = Input.GetAxis("Vertical");

        float hMov = joystick.Horizontal();
        float vMov = joystick.Vertical();

        //transform.position = 
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(hMov, vMov, 0.0f) * speed;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, left, rigth),
            Mathf.Clamp(transform.position.y, down, up),
            transform.position.z);
        transform.rotation = Quaternion.Euler(0, -rigidBody.velocity.x * 0.5f, 0);
    }

    private void Fire() {
        if (Input.GetAxis("Fire1") > 0) {
            Instantiate(projectile).transform.position = transform.position;
        }
    }
}

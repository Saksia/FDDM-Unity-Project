using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipImpact : MonoBehaviour {
	public GameObject explosion;
	GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider collider)
	{
        GameObject prueba = collider.gameObject;

		if (collider.gameObject.tag == "Player")
		{
            int lifes = gameController.UpdateLifes();

            if(lifes <= 0){
                Destroy(Instantiate(explosion, collider.gameObject.transform.position,
                    collider.gameObject.transform.rotation),
                    3);
                Destroy(collider.gameObject);
            }

		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projImpact : MonoBehaviour {
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
        string prueba = collider.gameObject.tag;

        if (collider.gameObject.tag == "Asteroid")
        {
            Destroy(Instantiate(explosion, collider.gameObject.transform.position, collider.gameObject.transform.rotation), 3);
            Destroy(collider.gameObject);
            gameController.UpdateScore(10);
            Destroy(gameObject); 
        }
    }
}

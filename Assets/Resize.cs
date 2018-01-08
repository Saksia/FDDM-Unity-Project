using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ResizeMethod());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ResizeMethod() {
        for (int i = 0; i < 1000; i++) {
            transform.localScale = transform.localScale * 0.99f;
            yield return new WaitForSeconds(3f);
        }
    }
}

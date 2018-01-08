using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenExit : MonoBehaviour {
    float left, rigth, up, down;

    // Use this for initialization
    void Start () {
        left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x - 100;
        rigth = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).x + 100;
        up = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).y + 100;
        down = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).y - 100;
    }

    // Update is called once per frame
    void Update () {
        float x = transform.position.x;
        float y = transform.position.y;

        if (x < left || x > rigth || y < down || y > up) {
            Destroy(gameObject);
        }
	}
}

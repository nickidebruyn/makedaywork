using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {

    public float destroyDistance;
    public float speed;
    private bool dead = false;
    private Vector3 startPos;
    private RootGameManager rootGameManager;

    // Use this for initialization
    void Start () {

        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rootGameManager = Camera.main.GetComponent<RootGameManager>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!dead)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed * -1, Space.World);
        }

        float dist = Vector3.Distance(transform.position, startPos);
        if (dist >= destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col) {
        // print("Collision exit");
        if (col.CompareTag("Player")) {
            dead = true;

        }
    }
}

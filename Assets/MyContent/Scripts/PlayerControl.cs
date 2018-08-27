using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public GameObject explosion;
    public GameObject fire;
    private RootGameManager rootGameManager;

	// Use this for initialization
	void Start () {
        rootGameManager = Camera.main.GetComponent<RootGameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {

        //TODO: Create explosion
        GameObject ex = Instantiate(explosion) as GameObject;
        ex.transform.position = transform.position;

        GameObject f = Instantiate(fire) as GameObject;
        f.transform.localPosition = transform.position;
        f.transform.parent = transform;

        rootGameManager.gameover = true;


    }
}

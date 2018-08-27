using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour {

    public GameObject shadow;
    public GameObject canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void showShadow()
    {
        shadow.SetActive(true);
        canvas.SetActive(true);
        Debug.Log("true");
    }

    public void hideShadow()
    {
        shadow.SetActive(false);
        canvas.SetActive(false);
        Debug.Log("false");
    }

}

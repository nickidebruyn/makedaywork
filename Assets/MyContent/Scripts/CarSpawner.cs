using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

    public GameObject[] carsToChooseFrom;
    public Transform[] spawnPoints;
    public float spawnTime;

    private float spawnCounter = 0;
    private RootGameManager rootGameManager;

    // Use this for initialization
    void Start()
    {
        rootGameManager = Camera.main.GetComponent<RootGameManager>();

    }

    // Update is called once per frame
    void Update () {

        if (!rootGameManager.gameover)
        {
            spawnCounter += Time.deltaTime;

            if (spawnCounter >= spawnTime)
            {
                spawnACar();
                spawnCounter = 0;
            }
        }

		
	}


    void spawnACar()
    {
        if (spawnPoints != null && carsToChooseFrom != null)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length); //TODO: Get random point
            int carToSpawnIndex = Random.Range(0, carsToChooseFrom.Length); //TODO: Get random car

            Vector3 pos = spawnPoints[spawnPointIndex].localPosition;
            Quaternion rot = spawnPoints[spawnPointIndex].localRotation;

            GameObject car = carsToChooseFrom[carToSpawnIndex];

            GameObject go = Instantiate(car) as GameObject;
            go.transform.parent = transform;
            go.transform.localPosition = pos;
            go.transform.localRotation = rot;

        }
    }

}

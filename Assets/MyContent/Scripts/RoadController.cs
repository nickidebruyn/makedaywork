using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {

    public float scrollSpeed = 0.5F;
    private Renderer rend;
    private RootGameManager rootGameManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rootGameManager = Camera.main.GetComponent<RootGameManager>();
    }

    void Update()
    {
        if (!rootGameManager.gameover)
        {
            float offset = Time.time * scrollSpeed;
            rend.material.mainTextureOffset = new Vector2(offset, 0);
        }

    }
}

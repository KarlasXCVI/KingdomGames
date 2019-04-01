using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    Material material;
    Vector2 offset;
    public int xVelocity, yVelocity;


    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Use this for initialization
    void Start () {

        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update () {

        //Vector2 offset = new Vector2(Time.deltaTime * speed, 0);
        material.mainTextureOffset += offset * Time.deltaTime;
	}
}

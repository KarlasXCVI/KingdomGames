using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Transform Lookat;


    public float boundX = 2.0f;
    public float boundY = 1.5f;

    public float speed = 0.15f;

    private Vector3 desiredPos;

    public void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float dx = Lookat.position.x - transform.position.x;

        if (dx > boundX || dx < -boundX)
        {
            if (transform.position.x < Lookat.position.x)
            {
                delta.x = dx - boundX;

            }
            else
            {
                delta.x = dx + boundX;
            }
        }

        float dy = Lookat.position.y - transform.position.y;

        if (dx > boundY || dx < -boundY)
        {
            if (transform.position.y < Lookat.position.y)
            {
                delta.y = dy - boundY;

            }
            else
            {
                delta.y = dy + boundY;
            }
        }

        desiredPos = transform.position + delta;
        transform.position = Vector3.Lerp(transform.position, desiredPos, speed);
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Vector2 cameraPosition;

	// Use this for initialization
	void Start () {
        cameraPosition = new Vector2();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.touchCount > 0)
        {
            cameraPosition = transform.position;
            if(Input.GetTouch(0).deltaPosition.y != 0)
            {
                float newCameraY = cameraPosition.y - Input.GetTouch(0).deltaPosition.y * Time.deltaTime;
                if(newCameraY <= 6.27 && newCameraY >= -6.27)
                {
                    transform.position = new Vector3(transform.position.x, newCameraY, transform.position.z);
                }
            }
        }
	}
}
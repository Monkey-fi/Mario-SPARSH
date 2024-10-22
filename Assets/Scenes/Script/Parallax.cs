using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;  // Reference to the camera
    public float parallaxFactor;  // How much the background should move relative to the camera (smaller value means slower movement)

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Calculate how far the camera has moved relative to the start position
        float temp = (cam.transform.position.x * (1 - parallaxFactor));
        float dist = (cam.transform.position.x * parallaxFactor);

        // Move the background based on the camera position
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        // Loop the background if it goes too far from the camera
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}

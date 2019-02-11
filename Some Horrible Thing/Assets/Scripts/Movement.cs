using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//Use: Place on lights.
//Intent: To create an uneasy feeling. To make some lights shift in and out of the space or warp the space somehow


public class Movement : MonoBehaviour
{
    public float speed = 3.0f;
    public float maxZ = 13.0f;
    public float minZ = - 13.0f;

    private int _direction = 1;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,_direction *speed *Time.deltaTime);

        bool bounced = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            _direction = -_direction;
            bounced = true;
        }

        if (bounced)
        {
            transform.Translate(0,0,_direction*speed* Time.deltaTime);
        }

    }
}

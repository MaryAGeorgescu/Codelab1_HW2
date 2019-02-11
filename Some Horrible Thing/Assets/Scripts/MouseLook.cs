using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Use: Place on player controller.
//Intent: to be able to look around.
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY= 0,
        MouseX= 1,
        MouseY= 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>(); 
        // we are disabling physics in order to make sure all movement is only controlled by the mouse
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX){
           transform.Rotate(0, Input.GetAxis("Mouse X")* sensitivityHor, 0); //horizontal rotation 
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;
            
            transform.localEulerAngles = new Vector3(_rotationX,rotationY, 0);//vertical rotation 
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles=new Vector3(_rotationX, rotationY, 0);//both horizontal and vertical
        }
    }
}

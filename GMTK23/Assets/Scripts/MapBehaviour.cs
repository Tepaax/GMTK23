using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    private Vector3 Rotation;

    [SerializeField]
    private float CameraSpeed;
    [SerializeField]
    private Camera MainCamera;

    // Update is called once per frame
    void Update()
    {
        if(!MainCamera.isActiveAndEnabled)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Rotation = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Rotation = Vector3.down;
            }
            else
            {
                Rotation = Vector3.zero;
            }
            transform.Rotate(Rotation * CameraSpeed * Time.deltaTime);
        }
        
    }
}

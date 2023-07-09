using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapBehaviour : MonoBehaviour
{
    private Vector3 Rotation;

    [SerializeField]
    private float CameraSpeed;
    [SerializeField]
<<<<<<< Updated upstream
    private Camera MainCamera;
=======
    private float MapSpeed;
    [SerializeField]
    private Camera camera;
    
>>>>>>> Stashed changes

    private float horizontalInput;
    private Vector3 moveDirection;
    private Vector3 mapPosition;

    private void Start()
    {
        mapPosition = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(!MainCamera.isActiveAndEnabled)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Rotation = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Rotation = Vector3.down;
            }
            else
            {
                Rotation = Vector3.zero;
            }
            transform.Rotate(Rotation * CameraSpeed * Time.deltaTime);

            horizontalInput = Input.GetAxisRaw("Horizontal");
            MoveMap();
            Debug.Log(horizontalInput);
        }
        
    }
    void MoveMap()
    {
        moveDirection = this.transform.right * horizontalInput / MapSpeed; ;
        mapPosition += moveDirection;
        this.transform.position = mapPosition;
    }
}

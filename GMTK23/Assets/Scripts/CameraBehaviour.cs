using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private Vector3 CameraPosition;

    private float x;
    private float y;
    private Vector3 RotateValue;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            x = Input.GetAxis("Mouse X");
            y = Input.GetAxis("Mouse Y");

        
            RotateValue = new Vector3(y,x * -1.0f, 0);
            transform.eulerAngles = transform.eulerAngles - RotateValue;
        }
        
        MyInput();
        MoveCamera();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
     
    }

    void MoveCamera()
    {
        moveDirection = this.transform.forward * verticalInput + this.transform.right* horizontalInput;

        CameraPosition += moveDirection;
        this.transform.position = CameraPosition;
    }
}

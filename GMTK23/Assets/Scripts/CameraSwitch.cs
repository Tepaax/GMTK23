using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject Camera1;
    [SerializeField]
    private GameObject Camera2;
    private void Start()
    {
        Camera1.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        }
    }
}

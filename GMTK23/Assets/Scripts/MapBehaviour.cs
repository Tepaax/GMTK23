using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    private Vector3 Rotation;

    [SerializeField]
    private float Speed;
    [SerializeField]
    private Texture2D Texture;


    void test()
    {
        var pixel = Texture.GetPixel(Texture.width, Texture.height);
        Debug.Log(pixel);
    }
    // Update is called once per frame
    void Update()
    {
        test();
        if(Input.GetKey(KeyCode.D))
        {
            Rotation = Vector3.up;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            Rotation = Vector3.down;
        }
        else
        {
            Rotation = Vector3.zero;
        }
        transform.Rotate(Rotation * Speed * Time.deltaTime);
    }
}

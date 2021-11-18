using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1; //2.5f
    // la idea es modificarla desde Unity

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.up;
    }
}

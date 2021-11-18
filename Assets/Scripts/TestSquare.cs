using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSquare : MonoBehaviour
{
    public float Speed = 5; //variables serializables públicas MonoBehaviour aparecen en Unity

    [SerializeField]
    private GameObject bullet;

    // atributos - con el SerializeField se puede visualizar en Unity
    //[SerializeField]
    //private float SpeedPrivada = 1;
    
    //private int Health { get; set; }   // Property

    // los scripts/objetos en escena, heredan de MonoBehaviour (herencia final)

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    // Methods & Properties starts with Uppercase
    // transform.position es una property, los atributos se utilizan en otras cosas, como métodos
        
    private void Move()
    {
        //if (Input.GetKey(KeyCode.W))

        // axis
        //transform.position += Vector3.up * Speed * Time.deltaTime;

        //Time.deltaTime = intervalos de segundos entre frames
        //se puede mover en el eje del pj o del mundo

        transform.position += Speed * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;  //0 - 1 sólo dirección, no magnitud

        // al jugar con cubito y se necesita algo mas contenido, se normaliza
        // el movimiento más realista > Gravity por ejemplo

        // Edit > Project Settings > Input Manager        
    } 

    private void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

}

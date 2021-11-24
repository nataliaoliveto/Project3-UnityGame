using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private Material _material;
    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        _material.mainTextureOffset = offset;
    }
}

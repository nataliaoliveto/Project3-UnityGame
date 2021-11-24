using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicMovement : MonoBehaviour
{
    // la idea es modificarla desde Unity
    [SerializeField]
    private float speed = 1; //2.5f

    [SerializeField]
    private float marginY;

    [SerializeField]
    private UnityEvent onExitScreen;
    
    private float _realMargin;

    void Start()
    {
        _realMargin = GameManager.Instance.ScreenLimit.y + marginY;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameRunning) return;

        transform.position += speed * Time.deltaTime * Vector3.up;
    }

    // LateUpdate is called every frame after Update
    private void LateUpdate()
    {
        if(transform.position.y > _realMargin || 
           transform.position.y < -_realMargin)
        {
            onExitScreen?.Invoke();
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float amount)
    {
        speed = amount;
    }
}

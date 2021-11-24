using UnityEngine;
using UnityEngine.Events;

public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float marginY;

    [SerializeField]
    private UnityEvent onExitScreen;
    
    private float _realMargin;

    void Start()
    {
        _realMargin = GameManager.Instance.ScreenLimit.y + marginY;
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameRunning) return;

        transform.position += speed * Time.deltaTime * Vector3.up; 
    }

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

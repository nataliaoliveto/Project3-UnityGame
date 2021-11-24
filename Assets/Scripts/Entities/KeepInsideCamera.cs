using UnityEngine;

public class KeepInsideCamera : MonoBehaviour
{
    private float _widthBound;
    private float _heightBound;

    private Vector3 _currentPosition;

    private void Start()
    {
        Bounds objectBound = GetComponent<Collider2D>().bounds;

        _widthBound = GameManager.Instance.ScreenLimit.x - (objectBound.size.x / 2);
        _heightBound = GameManager.Instance.ScreenLimit.y - (objectBound.size.y / 2);
            
    }

    private void LateUpdate()
    {
        _currentPosition = transform.position;
        _currentPosition.x = Mathf.Clamp(_currentPosition.x, -_widthBound, _widthBound);
        _currentPosition.y = Mathf.Clamp(_currentPosition.y, -_heightBound, _heightBound);
        transform.position = _currentPosition;
    }
}

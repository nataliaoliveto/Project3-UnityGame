using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private TimerSpawn cloud;

    private float _screenLimitX;

    private void Start()
    {
        _screenLimitX = GameManager.Instance.ScreenLimit.x;
        cloud.Initialize(Spawner);
    }

    private void Spawner(GameObject cloudPrefab)
    {
        Instantiate(cloudPrefab, new Vector3(UnityEngine.Random.Range(-_screenLimitX, _screenLimitX), transform.position.y), Quaternion.identity);
    }
        
    private void Update()
    {
        if (GameManager.Instance.IsGameRunning)
        {
            cloud.OnTick();
        }
    }
    
}

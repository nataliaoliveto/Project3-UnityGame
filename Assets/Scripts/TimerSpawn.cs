using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class TimerSpawn 
{
    [SerializeField]
    private GameObject gameObject;
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;

    public event Action<GameObject> OnTimeToSpawn = delegate { };
    private float _currentTimer;

    public void OnTick()
    {
        if(_currentTimer > 0)
        {
            _currentTimer -= Time.deltaTime;
        }
        else
        {
            OnTimeToSpawn?.Invoke(gameObject);
            Reset();
        }
    }

    public void Reset()
    {
        _currentTimer = GetRandomTime();
    }

    private float GetRandomTime()
    {
        return UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
    }

}

using System;
using UnityEngine;

[Serializable]
public class TimerSpawn : ObjectSpawn
{
    [SerializeField]
    private float minSpawnTime;
    [SerializeField]
    private float maxSpawnTime;

    private float _currentTimer;

    public override bool OnTick()
    {
        if (!Initialized) return false;

        if(_currentTimer > 0)
        {
            _currentTimer -= Time.deltaTime;
        }
        else
        {
            OnTimeToSpawn?.Invoke(prefab);
            Reset();
            return true;
        }
        return false;
    }

    public override void Reset()
    {
        _currentTimer = GetRandomTime();
    }

    private float GetRandomTime()
    {
        return UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
    }

}

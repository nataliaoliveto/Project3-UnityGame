using System;
using UnityEngine;

[Serializable]
public abstract class ObjectSpawn
{
    [SerializeField]
    protected GameObject prefab;

    protected Action<GameObject> OnTimeToSpawn;

    protected bool Initialized;
    public virtual void Initialize(Action<GameObject> objectCreator)
    {
        if (Initialized) return;
        Initialized = true;

        OnTimeToSpawn = objectCreator;

        Reset();
    }

    public abstract bool OnTick();
    public abstract void Reset();
}

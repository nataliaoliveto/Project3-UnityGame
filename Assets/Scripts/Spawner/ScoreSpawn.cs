using System;
using UnityEngine;

[Serializable]
public class ScoreSpawn : ObjectSpawn
{
    [SerializeField]
    private float scoreToSpawn;

    private int _previousScore;

    public override bool OnTick()
    {
        if (!Initialized) return false;
                
        if(GameManager.Instance.Score - _previousScore >= scoreToSpawn)
        {
            OnTimeToSpawn?.Invoke(prefab);
            Reset();
            return true;
        }

        return false;
    }

    public override void Reset()
    {
        _previousScore = GameManager.Instance.Score;
    }


}

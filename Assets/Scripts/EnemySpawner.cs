using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // variable privada serializada con minuscula
    // variable privada inicia con _

    [SerializeField]
    private TimerSpawn enemyEasy;
    [SerializeField]
    private TimerSpawn enemyMedium;

    private float _screenLimitX;

    // Start is called before the first frame update
    void Start()
    {
        _screenLimitX = GameManager.Instance.ScreenLimit.x;
        ResetTimers();
        enemyEasy.OnTimeToSpawn += SpawnEnemy;
        enemyMedium.OnTimeToSpawn += SpawnEnemy;
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, new Vector3(UnityEngine.Random.Range(-_screenLimitX, _screenLimitX), transform.position.y), Quaternion.identity);
        
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameRunning)
        {
            enemyEasy?.OnTick();
            enemyMedium?.OnTick();
        }
    }

    private void ResetTimers()
    {
        enemyEasy.Reset();
        enemyMedium.Reset();
    }

}

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private TimerSpawn enemyEasy;
    [SerializeField]
    private TimerSpawn enemyMedium;
    [SerializeField]
    private ScoreSpawn enemyHard;

    private float _screenLimitX;

    private void Start()
    {
        _screenLimitX = GameManager.Instance.ScreenLimit.x;
        enemyEasy.Initialize(SpawnEnemy);
        enemyMedium.Initialize(SpawnEnemy);
        enemyHard.Initialize(SpawnEnemy);
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, new Vector3(UnityEngine.Random.Range(-_screenLimitX, _screenLimitX), transform.position.y), Quaternion.identity);
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameRunning)
        {
            if (enemyHard.OnTick())
            {
                enemyMedium.Reset();
                enemyEasy.Reset();
            }

            if (enemyMedium.OnTick())
                enemyEasy.Reset();

            enemyEasy.OnTick();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //variable privada serializada con minuscula
    // variable privada inicia con _

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float minSpawnTime = 1f;

    [SerializeField]
    private float maxSpawnTime = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
        // empieza con coroutina hasta el yield time => vuelve a Unity y después de ese tiempo, le devuelve el control a la coroutina
        // en este caso sirve para no calcular timers
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (GameManager.Instance.IsGameRunning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            float screenLimitX = GameManager.Instance.ScreenLimit.x;
            //quaternion en 0, no utilizamos rotación
            Instantiate(enemyPrefab, new Vector3(Random.Range(-screenLimitX, screenLimitX), transform.position.y), Quaternion.identity);
        }
    }

}

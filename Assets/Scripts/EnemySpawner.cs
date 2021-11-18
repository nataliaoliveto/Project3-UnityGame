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
    private float spawnTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        // empieza con coroutina hasta el yield time => vuelve a Unity y después de ese tiempo, le devuelve el control a la coroutina
        // en este caso sirve para no calcular timers
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            //quaternion en 0, no utilizamos rotación
        }
    }

}

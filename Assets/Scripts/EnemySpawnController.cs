using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public float enemySpawnTimer = 3f;
    public float enemySpeed = 2f;

    public float randomPosX;
    public float randomPosY;
    public float randomPosZ;

    public Vector3 enemyPosition;
    public Vector3 enemyHitTargetPosition;

    public GameObject enemyHitTarget;

    private int enemyCount;

    private void Start()
    {
        enemyHitTargetPosition = new Vector3(enemyHitTarget.transform.position.x, enemyHitTarget.transform.position.y, enemyHitTarget.transform.position.z);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (enemyCount < 10)
        {
            randomPosX = Random.Range(-15f, 15f);
            randomPosY = Random.Range(0f, 10f);
            randomPosZ = Random.Range(-15f, 15f);
            enemyPosition = new Vector3(randomPosX, randomPosY, randomPosZ);
            Instantiate(enemyPrefab, enemyPosition, gameObject.transform.rotation);
            //enemyPrefab.transform.position = Vector3.Lerp(enemyPosition, enemyHitTargetPosition, enemySpeed * Time.deltaTime);
            //enemyPrefab.transform.position = Vector3.MoveTowards(enemyPosition, enemyHitTargetPosition, enemySpeed * Time.deltaTime);
            yield return new WaitForSeconds(enemySpawnTimer);
            enemyCount += 1;
        }
    }

    void Update()
    {
        if (enemyPrefab.transform.position != enemyHitTargetPosition)
        {
            enemyPrefab.transform.position = Vector3.MoveTowards(enemyPosition, enemyHitTargetPosition, enemySpeed * Time.deltaTime);
        }
        else
        {
            Destroy(enemyPrefab);
        }
    }
}
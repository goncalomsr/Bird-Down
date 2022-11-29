using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;

    [HeaderAttribute ("Spawn Settings")] 
    public float enemySpawnTimer = 3f;
    public float enemySpeed = 2f;
    private float randomPosX;
    private float randomPosY;
    private float randomPosZ;
    public Vector3 enemyPosition;
    public Vector3 enemyHitTargetPosition;

    [HeaderAttribute("Enemy Target")]
    public GameObject enemyHitTarget;

    [HeaderAttribute("Wave Settings")]
    private bool enemyWave = true;
    private int enemyCount;

    private void Start()
    {
        enemyHitTargetPosition = new Vector3(enemyHitTarget.transform.position.x, enemyHitTarget.transform.position.y, enemyHitTarget.transform.position.z);
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (enemyWave)
        {
            if (enemyCount < 10)
            {
                randomPosX = Random.Range(-15f, 15f);
                randomPosY = Random.Range(0f, 10f);
                randomPosZ = Random.Range(-15f, 15f);
                enemyPosition = new Vector3(randomPosX, randomPosY, randomPosZ);
                Instantiate(enemyPrefab, enemyPosition, gameObject.transform.rotation);

                enemyCount++;
            }
            
            yield return new WaitForSeconds(enemySpawnTimer);
        }
    }

    public void DeductEnemyCount()
    {
        enemyCount--;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Animator enemyAnimator;
    public float enemySpawnTimer = 3f;
    public float randomPosX;
    public float randomPosY;
    public float randomPosZ;
    private Vector3 enemyPosition;

    void Update()
    {
        print("spawn!");
        if (Time.time > enemySpawnTimer)
        {
            randomPosX = Random.Range(-30f, 30f);
            randomPosY = Random.Range(0f, 20f);
            randomPosZ = Random.Range(-30f, 30f);
            enemyPosition = new Vector3(randomPosX, randomPosY, randomPosZ);
            enemySpawnTimer += 3f;
            Instantiate(enemyPrefab, enemyPosition, gameObject.transform.rotation);
            enemyAnimator.Play("flapWings");
        }
    }
}
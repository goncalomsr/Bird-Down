using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Animator enemyAnimator;

    public bool enemyLerping = true;
    public float enemySpeed = 2f;

    void Start()
    {
        //enemyAnimator = enemySpawnScript.enemyPrefab.GetComponent<Animator>();
        //enemyAnimator.Play("flapWings");
    }
}

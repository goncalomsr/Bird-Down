using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    LevelController levelController;

    private GameObject balloonTarget;
    private Animator enemyAnimator;

    public float enemySpeed = 2f;

    void Start()
    {
        balloonTarget = GameObject.FindGameObjectWithTag("Balloon");
        enemyAnimator = GetComponent<Animator>();
        levelController = GameObject.Find("SceneController").GetComponent<LevelController>();
    }

    void Update()
    {
        transform.LookAt(balloonTarget.transform.position);

        if (Vector3.Distance(transform.position, balloonTarget.transform.position) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, balloonTarget.transform.position, enemySpeed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            levelController.IncrementPoints();
        }
    }
}

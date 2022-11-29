using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// Determine force of projectile
    /// Set projectile Rigid Body
    /// </summary>
    [SerializeField] float projectileForce = 50f;
    Rigidbody projectileRB;
    private float timeAfterInstanciate;
    public EnemySpawnController enemySpawnController;

    private void Start()
    {
        /// <summary>
        /// Get projectile Rigid Body
        /// Apply force on projectile
        /// </summary>
        projectileRB = GetComponent<Rigidbody>();
        projectileRB.AddForce(transform.forward * projectileForce, ForceMode.Impulse);
        StartCoroutine(selfDestruct());
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnPoint : MonoBehaviour
{
    /// <summary>
    /// Getting the game objects to determine
    /// Spawn Location and Projectile object
    /// </summary>
    [SerializeField] GameObject projectileSpawnPoint;
    [SerializeField] GameObject projectileObject;

private void Update()
    {
        /// <summary>
        /// Condition to instanciate projectile
        /// </summary>
        if (Input.GetMouseButtonDown(0))
        {
            print("clicked");
            Instantiate(projectileObject, projectileSpawnPoint.transform.position, projectileSpawnPoint.transform.rotation);
        }
    }
}

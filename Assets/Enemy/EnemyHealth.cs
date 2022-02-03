using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Triggering");
        currentHitPoints++;
        if (currentHitPoints >= maxHitPoints)
        {
            Destroy(this.gameObject);
        }
    }
}
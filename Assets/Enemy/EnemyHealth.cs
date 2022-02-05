using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    Enemy enemy;

    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            enemy.RewardGold();
            this.gameObject.SetActive(false);
        }
    }
}
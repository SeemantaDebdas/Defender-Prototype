using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float rotationSpeed = 0.2f;
    [SerializeField] Vector3 targetOffset;
    [SerializeField] float weaponRange;

    Transform enemy;
    ParticleSystem boltParticleSystem;

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            if (child.childCount > 0)
                boltParticleSystem = child.GetChild(0).GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        AimWeapon();
    }

    void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distanceFromEnemy = Vector3.Distance(enemies[i].transform.position, transform.position);
            if (distanceFromEnemy < maxDistance)
            {
                closestTarget = enemies[i].transform;
                maxDistance = distanceFromEnemy;
            }
        }

        enemy = closestTarget;
    }

    private void AimWeapon()
    {
        if (enemy == null) Attack(false);
        else {
            Quaternion targetRotation = Quaternion.LookRotation((enemy.position + targetOffset) - weapon.position);
            weapon.transform.rotation = Quaternion.Lerp(weapon.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            Attack(Vector3.Distance(transform.position, enemy.position) <= weaponRange);
        }
        
    }

    void Attack(bool canAttack)
    {
        var emissionModule = boltParticleSystem.emission;
        emissionModule.enabled = canAttack;
    }
}

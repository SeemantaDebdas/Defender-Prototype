using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform enemy;
    [SerializeField] float rotationSpeed = 0.2f;
    [SerializeField] Vector3 targetOffset;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
            AimWeapon();
    }

    private void AimWeapon()
    {
        Quaternion targetRotation = Quaternion.LookRotation((enemy.position + targetOffset)  - weapon.position);
        weapon.transform.rotation = Quaternion.Lerp(weapon.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

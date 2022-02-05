using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    Bank bank;
    public bool CreateTower(GameObject towerPrefab, Vector3 spawnPosition)
    {
        bank = FindObjectOfType<Bank>();
        if (bank == null) return false;

        if(bank.GetCurrentBankAmount >= cost)
        {
            Instantiate(towerPrefab, spawnPosition, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
}

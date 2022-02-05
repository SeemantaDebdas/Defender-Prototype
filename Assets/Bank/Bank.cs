using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int initialAmount;
    [SerializeField]
    int currentAmount;
    public int GetCurrentBankAmount { get { return currentAmount; } }

    void Awake()
    {
        currentAmount = initialAmount;
    }

    public void Deposit(int amount) => currentAmount += Mathf.Abs(amount);

    public void Withdraw(int amount)
    {
        currentAmount -= Mathf.Abs(amount);
        if (currentAmount <= 0)
            print("You lost!");
    }
}

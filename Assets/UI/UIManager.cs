using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    [SerializeField] TextMeshProUGUI goldText;

    private void Awake()
    {
        instance = this;
    }

    public void SetGoldText(string text) => goldText.text = "Gold: " + text;
}

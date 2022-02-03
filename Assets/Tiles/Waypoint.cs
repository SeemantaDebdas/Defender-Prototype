using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            isPlaceable = false;
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
        }
            
    }
}

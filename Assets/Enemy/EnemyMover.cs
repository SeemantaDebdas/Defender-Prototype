using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints;

    private void Start()
    {
        if(waypoints != null)
            StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in waypoints)
        {
            transform.position = waypoint.transform.position;
            //transform.position = new Vector3(waypoint.transform.position.x, transform.position.y, waypoint.transform.position.z);
            yield return new WaitForSeconds(1f);
        }
    }
}

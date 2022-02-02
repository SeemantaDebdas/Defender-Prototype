using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints = new List<Waypoint>();

    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in waypoints)
        {
            Vector3 startPostion = transform.position;
            Vector3 endPosition = waypoint.transform.position;

            //Quaternion startRotation = transform.rotation;
            //Quaternion endRotation = Quaternion.LookRotation(transform.position, waypoint.transform.position);

            //float rotatePercent = 0f;
            //while (rotatePercent < 1f)
            //{
            //    rotatePercent += Time.deltaTime;
            //    transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotatePercent);
            //}
            

            float travelPercent = 0f;

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime;
                Debug.Log(travelPercent);
                transform.position = Vector3.Lerp(startPostion, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

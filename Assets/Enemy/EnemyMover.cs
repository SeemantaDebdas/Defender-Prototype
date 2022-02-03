using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> waypoints = new List<Waypoint>();
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float moveSpeed = 5f;

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

            Quaternion startRotation = transform.rotation;
            Quaternion endRotation = Quaternion.LookRotation(waypoint.transform.position - transform.position);

            //float rotatePercent = 0f;
            //while (rotatePercent < 1f)
            //{
            //    rotatePercent += Time.deltaTime * rotationSpeed;
            //    transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotatePercent);
            //    yield return new WaitForEndOfFrame();
            //}

            //float travelPercent = 0f;

            //while (travelPercent < 1f)
            //{
            //    travelPercent += Time.deltaTime * moveSpeed;
            //    transform.position = Vector3.Lerp(startPostion, endPosition, travelPercent);
            //    yield return new WaitForEndOfFrame();
            //}

            float travelPercent = 0f;
            float rotatePercent = 0f;

            while (travelPercent < 1f || rotatePercent < 1f)
            {
                travelPercent += Time.deltaTime * moveSpeed;
                rotatePercent += Time.deltaTime * rotationSpeed;

                transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotatePercent);
                transform.position = Vector3.Lerp(startPostion, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public PlayerNoiseOutput _PlayerNoiseOutput;

    //public Transform NoisePoint;   //This will be the point where noise was last heard


    public Transform target;
    float speed = 5;
    Vector3[] path;
    int targetIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))  // R starts the path following.
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }
        if (Input.GetKeyDown(KeyCode.T))  // T stops the pathfinding.
        {
            StopCoroutine("FollowPath");

        }

    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {               
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }


            var targetRotation = Quaternion.LookRotation(currentWaypoint - transform.position);          
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);  //Rotates the player, while smoothing.


            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
           
        }
        
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}
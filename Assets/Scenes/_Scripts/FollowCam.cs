using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Header")]
    public float   easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        // return if no POI
        // if (POI == null) return;

        // get position of POI
        // Vector3 destination = POI.transform.position;
        Vector3 destination;
        // if no POI, return P:[0,0,0]
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            // if POI is projectile, check if its at rest
            if (POI.tag == "Projectile")
            {
                //if not moving (sleeping)
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        // set camera to destination
        transform.position = destination;
        // set orthographicSize of camera to keep ground in view
        Camera.main.orthographicSize = destination.y + 10;
    }
}

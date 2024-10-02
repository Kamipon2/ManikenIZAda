using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForHim : MonoBehaviour
{
    public int RayCastCountX;
    public int RayCastCountY;
    public float POVraycast;
    public Transform tochka;
    public RaycastHit[] hit = new RaycastHit[50];
    public Ray[] ray = new Ray[50];

    // Update is called once per frame
    void Update()
    {
        
        for(int i = 0; i < RayCastCountX;)
        {
            ray[i] = new Ray(transform.position, new Vector3(transform.forward.x, transform.forward.y, transform.forward.z));
            Physics.Raycast(ray[i], out hit[i]);
            //Debug.DrawLine (transform.position, new Vector3(transform.forward.x*(i/RayCastCountX), transform.forward.y, transform.forward.z), Color.green);
            Debug.DrawRay(transform.position, new Vector3(transform.forward.x + ((i + (RayCastCountX -  (RayCastCountX * 1.5f)))/POVraycast), transform.forward.y, transform.forward.z + ((i + (RayCastCountX -  (RayCastCountX * 1.5f)))/POVraycast)) * 100);
            i++;
        }
        Debug.Log(transform.forward);
    }
}

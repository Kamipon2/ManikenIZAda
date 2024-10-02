using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousec : MonoBehaviour
{
    public static int cutscene = 0;
    public enum RorationAxes
    {
        XandY,
        X,
        Y


    }
    
    public RorationAxes _axes = RorationAxes.XandY;
    public float _rspeed = 5.0f;
    public float _rspeedv = 5.0f;
    public float maxVert = 5.0f;
    public float minVert =-5.0f;
    private float _rotationx = 0;
    public Transform cam1;
    public Transform pla1;
    public float chust;

    private void Awake()
    {
      

    }
    
    private void Update()
    {
      if(cutscene == 0)
      {
       if(_axes == RorationAxes.XandY)
       {

        
         _rotationx -= Input.GetAxis("Mouse Y")* chust;
         _rotationx = Mathf.Clamp(_rotationx, minVert, maxVert);
         float delta = Input.GetAxis("Mouse X")* chust;
         float _rotationy = transform.localEulerAngles.y + delta;
         transform.localEulerAngles = new Vector3(_rotationx, _rotationy, 0);
      
       }
       if(_axes == RorationAxes.X)
       {
         //transform.Rotate(0, Input.GetAxis("Mouse X") * settings1.chust, 0);
         transform.Rotate(0, Input.GetAxis("Mouse X") * 5, 0);

        
       }
       if(_axes == RorationAxes.Y)
       {
       
         //_rotationx -= Input.GetAxis("Mouse Y")* settings1.chust;
         _rotationx -= Input.GetAxis("Mouse Y")* 5;
         _rotationx = Mathf.Clamp(_rotationx, minVert, maxVert);
         float _rotationy = transform.localEulerAngles.y;
         transform.localEulerAngles = new Vector3(_rotationx, _rotationy, 0);
       }
      }


      

    }
}

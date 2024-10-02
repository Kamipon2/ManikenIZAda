using System;
using UnityEngine;
public class podnyatie_obj : MonoBehaviour
{
    public float grabPower = 10.0f;//скорость притяжения
    public int throwPower = 10;//скорость толчка
    public RaycastHit hit;//луч
    public int RayDistance = 3;//дистанция
    private bool Grab = false;//ф-ция притяжения
    private bool Throw = false;//ф-ция толчка
    public Transform offset;
    public bool Player1;
    public bool Useless;
    public bool Kidala;

void Update()
{
    if(Player1)
    {
       if (Input.GetKeyDown(KeyCode.E))//если нажата клавиша Е
       {
           if(Grab)
           {
              hit.rigidbody.velocity = transform.forward * 0;
              Grab = false;
              if(hit.collider.gameObject.GetComponent<playerctrl>())
              {
                 hit.collider.gameObject.GetComponent<playerctrl>().enabled = true;
              }
              Kidala = false;
              
           }
           else
           {
              Physics.Raycast(transform.position, transform.forward, out hit, RayDistance);//физический луч
              if(hit.rigidbody){
                  if(hit.collider.gameObject.GetComponent<playerctrl>())
                  {
                      hit.collider.gameObject.GetComponent<playerctrl>().enabled = false;
                  }//если луч соприкасается с rigidbody
                  Grab = true;
                  Kidala = true;
              }
           }
       }
    }
    if(Player1)
    {
        if(Kidala)
        {
           if (Input.GetMouseButtonDown(0)){//если нажата лев кн мыши
                if(Grab)
                {
                  if(hit.collider.gameObject.GetComponent<playerctrl>())
                  {
                      hit.collider.gameObject.GetComponent<playerctrl>().enabled = true;
                  }
                  Grab = false;
                  Throw = true;
                  Kidala = false;
                }
        }
            
    }


    
}

if(Grab){//ф-ция притяжения
if(hit.rigidbody){
hit.rigidbody.velocity = (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass))*grabPower;
//hit.transform.eulerAngles = new Vector3(0,0,0);
}
}

if(Throw){//ф-ция толчка
if(hit.rigidbody){
hit.rigidbody.velocity = transform.forward * throwPower;
Throw = false;
}
}
}
}

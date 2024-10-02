using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerctrl : MonoBehaviour
{
    public float speed = 100f;
    public float hspeed = 120f;
    public float tolc = 100f;
    private Rigidbody dvis;
    public float tolc1 = 500f;
    public byte prig = 1;
    public float hor;
    public float ver;
    private void Awake()
    {
        dvis = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
      hor = Input.GetAxis("Horizontal");
      ver = Input.GetAxis("Vertical");
      
      float h = hor * hspeed * Time.fixedDeltaTime;
      float v = ver * speed * Time.fixedDeltaTime;



      dvis.velocity = transform.TransformDirection(new Vector3(h, dvis.velocity.y, v));
       
    }

    //private void OnTriggerEnter(Collider other)
    //{
        //if(other.gameObject.tag == "collictive")
          //Instantiate(obj, new Vector3(UnityEngine.Random.Range(-6f, 6.5f),1.2f,UnityEngine.Random.Range(-17.0f, 1-3.7f)), Quaternion.Euler(90, 0, 0));
           //Destroy(other.gameObject);
           //score = score+1;
           //scoreText.text = "score:" + score;

    //}

     bool isLocked;
 // Use this for initialization
 void Start () {
  SetCursorLock (true);
 }

 void SetCursorLock(bool isLocked) {
  this.isLocked = isLocked;
  Screen.lockCursor = isLocked;
  Cursor.visible = !isLocked;
 }
 // Update is called once per frame
 public void Update () 
 {
  if (Input.GetKeyDown (KeyCode.Tab))
   //SetCursorLock (!isLocked);
  if (Input.GetKeyDown ("Space"))
  {
    if (prig == 1)
    {
        dvis.AddForce(new Vector3(0,10000,0));
        prig = 0;
    }
  }
 }
 public void OnCollisionEnter(Collision other)
 {
    prig = 1;
 }
 
}


   


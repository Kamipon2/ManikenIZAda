using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavAgent : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public GameObject[] tochki;
    public AnimationClip[] anim;
    public Animation animAgent;
    public bool Scrimer;
    public Transform ruka;

    void Start()
    {
        StartCoroutine("say");
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance <= 0.2f)
        {
            StartCoroutine("say");
        }
    }
    IEnumerator say()
    {
        if(!Scrimer)
        {
           agent.SetDestination(tochki[Random.Range(0, tochki.Length)].transform.position);
           yield return null;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player")
        {
            agent.enabled = false;
            Scrimer = true;
            animAgent.Play("Attack");
            other.gameObject.GetComponent<playerctrl>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = ruka.position;
            other.transform.SetParent(ruka);


        }
    }
}
                                    
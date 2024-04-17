using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public GameObject theMonster;

    void OnTriggerEnter(Collider other)
    {
        theMonster.GetComponent<Animator>().Play("Attack1");
        theMonster.GetComponent<NavigationAI>().enabled = false;
        theMonster.GetComponent<NavMeshAgent>().enabled = false;
    }

    void OnTriggerExit(Collider other)
    {
        theMonster.GetComponent<Animator>().Play("Walk");
        theMonster.GetComponent<NavigationAI>().enabled = true;
        theMonster.GetComponent<NavMeshAgent>().enabled = true;
    }

}

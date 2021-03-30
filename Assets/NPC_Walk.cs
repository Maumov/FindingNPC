using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum NPCStatus
{
    idle, wandering, goingToSpot, none
}
public class NPC_Walk : MonoBehaviour
{
    [SerializeField] NPCStatus nPCStatus;
    [SerializeField] float distanceToReachTargetPosition = .5f;
    NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        nPCStatus = NPCStatus.none;
        StartCoroutine(Idleing());
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValues();
    }

    [SerializeField] private float idleWaitUntilNextWalk = 5f;
    IEnumerator Idleing() {
        float currentTime = Random.Range(1f, idleWaitUntilNextWalk);
        while(currentTime > 0f) {
            nPCStatus = NPCStatus.idle;
            currentTime -= Time.deltaTime;
            yield return null;
        }
        StartCoroutine(GoingToSpot());
        yield return null;
    }

    bool isWalking = false;
    IEnumerator GoingToSpot() {
        agent.isStopped = false;
        Vector3 targetPosition = FindObjectOfType<SolidRectangle>().GetRandomPositionInsideArea();
        agent.SetDestination(targetPosition);
        nPCStatus = NPCStatus.goingToSpot;
        isWalking = true;
        while(agent.remainingDistance > distanceToReachTargetPosition) {

            yield return null;
        }

        agent.isStopped = true;
        StartCoroutine(Idleing());
        isWalking = false;
        yield return null;
    }

    void SetAnimatorValues() {
        if(anim != null) {
            anim.SetBool("isWalking", isWalking);
        } else {
            anim = GetComponentInChildren<Animator>();
        }   
    }

}

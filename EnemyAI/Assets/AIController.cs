using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController: MonoBehaviour {
        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
        public float  offsetX;
        public float offsetZ;
        public Transform target;

        Vector3 heading;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
        agent.autoBraking = false;
        GotoNextPoint();
	}
	
	// Update is called once per frame
	void Update () {
		     // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

            //target player instead
            if(!target){
                Debug.Log("Player not found");
            }

            heading = gameObject.transform.position - target.position;
            if(Mathf.Abs(heading.x) <= offsetX && Mathf.Abs(heading.z) <= offsetZ){
                GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target.transform.position;
            }


	}

	void GotoNextPoint(){
	  if (points.Length == 0)
		  return;

    // Set the agent to go to the currently selected destination.
    agent.destination = points[destPoint].position;
    // Choose the next point in the array as the destination,
    // cycling to the start if necessary.
    destPoint = (destPoint + 1) % points.Length;
	}
}

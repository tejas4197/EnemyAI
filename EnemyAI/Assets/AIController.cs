using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController: MonoBehaviour {
        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

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

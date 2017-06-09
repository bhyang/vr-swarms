using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour {

    public static List<Bug> swarm = new List<Bug>();
    public static int counter = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // update all of the bug positions
        UpdateSwarm();
        


    }

    void UpdateSwarm()
    {
        List<Point> vectors = new List<Point>();
        for (int i = 0; i < swarm.Count; i++)
        {
            Bug b = swarm[i];
            Point v1 = b.FlyTowardsCenter();
            Point v2 = b.KeepDistance();
            Point v3 = b.MatchVelocity();

            vectors.Add(v1.add(v2.add(v3)));
        }
        for (int i = 0; i < swarm.Count; i++)
        {
            swarm[i].velocity = swarm[i].velocity.add(vectors[i]);
        }
        foreach (Bug b in swarm)
        {
            b.p = b.p.add(b.velocity);
        }
    }
}

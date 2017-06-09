using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmController : MonoBehaviour {

    public static List<Bug> swarm = new List<Bug>();
    public static int counter = 0;

    public static Point locus = new Point(50, 50, 50);

    // Factors for strength of respective rules
    public static double M1 = 1;
    public static double M2 = 1;
    public static double M3 = 1;
    public static double M4 = 1;

	// Use this for initialization
	void Start () {}

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

            Point v1 = b.FlyTowardsCenter().multiply(M1);
            Point v2 = b.KeepDistance().multiply(M2);
            Point v3 = b.MatchVelocity().multiply(M3);
            Point v4 = b.TendToPlace(locus).multiply(M4);

            vectors.Add(v1.add(v2.add(v3.add(v4)));
        }
        for (int i = 0; i < swarm.Count; i++)
        {
            swarm[i].velocity = swarm[i].velocity.add(vectors[i]);
            swarm[i].LimitVelocity();
        }
        foreach (Bug b in swarm)
        {
            b.p = b.p.add(b.velocity);
        }
    }
}

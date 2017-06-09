using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWrapper : MonoBehaviour {
    Bug b;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3((float)Random.Range(0, 20), (float)Random.Range(0, 20), (float)Random.Range(0, 20));
        b = new Bug(SwarmController.counter++, new Point(transform.position.x, transform.position.y, transform.position.z));
        SwarmController.swarm.Add(b);
        Debug.Log(b.id);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3((float)b.p.x, (float)b.p.y, (float)b.p.z);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractScript : MonoBehaviour {
    Vector3 GetPosition()
    {
        return transform.position;
    }
	// Update is called once per frame
	void Update () {
        AttractScript[] attractors = FindObjectsOfType<AttractScript>();
        for (int i = 0; i < attractors.Length; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, attractors[i].GetPosition(), 0.01f);
        }
	}
}

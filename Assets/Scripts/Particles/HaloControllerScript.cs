using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateHalo();

    }

    private void UpdateHalo()
    {
        foreach (FormulaScript script in GetComponents<FormulaScript>())
        {
            if (script.achieved)
            {
                (GetComponent("Halo") as Behaviour).enabled = true;
                return;
            }
        }
        (GetComponent("Halo") as Behaviour).enabled = false;
    }
}

using Reactives;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestScript : MonoBehaviour {

    //public Dictionary<Reactive, int> particles;
    public List<ParticlesProbability> particles;
    public int generateProbabilityPercent;
    private int totalProbability;
    private System.Random randomizer = new System.Random();
    void Start () {
        totalProbability = 1;
		foreach (ParticlesProbability proba in particles)
        {
            totalProbability += proba.probability;
        }
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (randomizer.Next(100) < generateProbabilityPercent)
            {
                int random = randomizer.Next(totalProbability);
                int currentProba = 0;
                foreach (ParticlesProbability proba in particles)
                {
                    if (random <= currentProba + proba.probability)
                    {
                        proba.particle.Increment();
                        break;
                    }
                    currentProba += proba.probability;
                }
            }
        }

    }

    [Serializable]
    public class ParticlesProbability
    {
        public Reactive particle;
        public int probability;
    }
}

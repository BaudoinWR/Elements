using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Reactives;

public class FormulaScript : MonoBehaviour {
    public Reactive[] components;
    public Reactive result;
    public IDictionary<GameObject, Reactive> colliding = new Dictionary<GameObject, Reactive>();
    Behaviour halo;
    float detachedBuffer = 0.1f;
    float timeDetached = -1;
    public bool achieved = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FormulaScript>() != null)
        {
            if (!colliding.ContainsKey(collision.gameObject))
            {
                colliding.Add(collision.gameObject, collision.gameObject.GetComponent<ParticleScript>().reactive);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FormulaScript>() != null)
        {
            colliding.Remove(collision.gameObject);
        }
    }

    void Start () {
        halo = (Behaviour) GetComponent("Halo");
        halo.enabled = false;
	}
	
	void Update ()
    {
        ICollection<GameObject> constituents;
        if (IsUsable(out constituents))
        {
            FormulaActivationScript.AddFormula(result.GetParticleObject(), gameObject, constituents);
            timeDetached = -1;
            achieved = true;
        }
        else if (achieved)
        {
            if (timeDetached == -1)
            {
                timeDetached = Time.time;
            }
            else if (Time.time - timeDetached > detachedBuffer)
            {
                FormulaActivationScript.Remove(result.GetParticleObject(), gameObject);
                achieved = false;
            }
        }
    }

    private bool IsUsable(out ICollection<GameObject> constituents)
    {
        constituents = new List<GameObject>();
        Dictionary<GameObject, Reactive> copy = new Dictionary<GameObject, Reactive>(colliding);
        foreach (Reactive react in components)
        {
            bool found = false;
            foreach (KeyValuePair<GameObject, Reactive> pair in copy)
            {
                if (pair.Value == react)
                {
                    constituents.Add(pair.Key);
                    copy.Remove(pair.Key);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return false;
            }
        }
        return true;
    }

}

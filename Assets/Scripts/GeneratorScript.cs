using Reactives;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorScript : MonoBehaviour {
    public Reactive particle;
    public int available = 1;
    private GameObject generated;
    private void Start()
    {
        particle.Increment(available);
        UpdateText();
    }

    private void Update()
    {
        available = particle.Get();
        UpdateText();
        GetComponent<SpriteRenderer>().color = particle.GetParticleObject().GetComponent<SpriteRenderer>().color;
    }

    void OnMouseDown()
    {
        if (available > 0)
        {
            generated = Instantiate(particle.GetParticleObject());
            generated.GetComponent<ParticleScript>().OnMouseDown();
            generated.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            generated.transform.position = new Vector3(generated.transform.position.x, generated.transform.position.y, 0);
            particle.Decrement();
        }
    }

    public void OnMouseUp()
    {
        if (generated != null)
        {
            generated.GetComponent<ParticleScript>().OnMouseUp();
            generated = null;
        }
    }

    private void UpdateText()
    {
        Text theText = GetComponentInChildren<Text>();
        theText.text = "" + particle.Get();
    }
}

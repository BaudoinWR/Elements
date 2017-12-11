using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorScript : MonoBehaviour {
    public GameObject particle;
    public int available = 1;
    private GameObject generated;
    private void Start()
    {
        UpdateText();
    }

    void OnMouseDown()
    {
        if (available > 0)
        {
            generated = Instantiate(particle);
            generated.GetComponent<ParticleScript>().OnMouseDown();
            generated.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            generated.transform.position = new Vector3(generated.transform.position.x, generated.transform.position.y, 0);
            available--;
        }
        UpdateText();
    }

    public void OnMouseUp()
    {
        generated.GetComponent<ParticleScript>().OnMouseUp();
    }

    private void UpdateText()
    {
        Text theText = GetComponentInChildren<Text>();
        theText.text = "" + available;
    }
}

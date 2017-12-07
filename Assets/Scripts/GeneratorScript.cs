using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorScript : MonoBehaviour {
    public GameObject particle;
    public int available = 1;

    private void Start()
    {
        UpdateText();
    }

    void OnMouseUp()
    {
        if (available > 0)
        {
            GameObject generated = Instantiate(particle);
            generated.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            generated.transform.position = new Vector3(generated.transform.position.x, generated.transform.position.y, 0);
            available--;
        }
        UpdateText();
    }

    private void UpdateText()
    {
        Text theText = GetComponentInChildren<Text>();
        theText.text = "" + available;
    }
}

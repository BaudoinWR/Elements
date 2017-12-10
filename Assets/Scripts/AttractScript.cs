using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractScript : MonoBehaviour {

    private bool dragging = false;
    Vector3 GetPosition()
    {
        return transform.position;
    }
	// Update is called once per frame
	void Update () {
        if (dragging)
        {
            GetComponent<Collider2D>().enabled = false;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
            AttractScript[] attractors = FindObjectsOfType<AttractScript>();
            for (int i = 0; i < attractors.Length; i++)
            {
                transform.position = Vector3.MoveTowards(transform.position, attractors[i].GetPosition(), 0.01f);
            }
        }
	}

    private void OnMouseDown()
    {
        dragging = true;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(2, 2, 1));
        GetComponent<Renderer>().sortingOrder = 1;
    }
    private void OnMouseUp()
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.5f, 0.5f, 1));
        dragging = false;
        GetComponent<Renderer>().sortingOrder = 0;
    }
}

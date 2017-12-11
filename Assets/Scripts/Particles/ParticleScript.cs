using Reactives;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

    private bool dragging = false;
    public Reactive reactive;
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
            ParticleScript[] particles = FindObjectsOfType<ParticleScript>();
            for (int i = 0; i < particles.Length; i++)
            {
                transform.position = Vector3.MoveTowards(transform.position, particles[i].GetPosition(), 0.01f);
            }
        }
	}

    public void OnMouseDown()
    {
        dragging = true;
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(2, 2, 1));
        GetComponent<Renderer>().sortingOrder = 1;
    }
    public void OnMouseUp()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint((Input.mousePosition)), Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<ParticlePlayAreaScript>() != null)
            {
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.5f, 0.5f, 1));
                dragging = false;
                GetComponent<Renderer>().sortingOrder = 0;
                return;
            }
        }
        reactive.Increment();
        Debug.Log(reactive.Get());
        Destroy(gameObject);
    }

}

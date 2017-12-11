using UnityEngine;

public class HoverScript : MonoBehaviour {

    public void Update()
    {
        DoHover();
    }

    public void DoHover()
    {
        transform.Translate(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), 0);
    }
    
}

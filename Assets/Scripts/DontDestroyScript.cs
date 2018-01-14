using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour {
    private Canvas canvas;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        canvas = GetComponent<Canvas>();
    }

private void Update()
    {
        if (canvas != null)
        {
            canvas.worldCamera = Camera.main;
        }
    }
}

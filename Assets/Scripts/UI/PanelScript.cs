using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {
    public GameObject target;
    public Vector3 initialPosition;
    public Vector3 targetPosition;
    public Vector3 movingTowards;

    private void Start()
    {
        Vector2 panelSize = new Vector2(
            GetComponent<RectTransform>().sizeDelta.x,
            GetComponent<RectTransform>().sizeDelta.y
        );
        gameObject.GetComponent<BoxCollider2D>().size = panelSize;
        initialPosition = (transform as RectTransform).localPosition;
        targetPosition = (target.transform as RectTransform).localPosition;
        movingTowards = initialPosition;
    }

    private void Update()
    {
        (transform as RectTransform).localPosition = Vector3.MoveTowards((transform as RectTransform).localPosition, movingTowards, 2f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.Equals(this.gameObject))
            {
                ToTarget();
                return;
            }
        }
        ToOrigin();
    }

    void ToTarget()
    {
        movingTowards = targetPosition;
        //Vector2.MoveTowards(transform.position, targetPosition.transform.position, 0.1f);
        //Debug.Log("enter");
        //GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RectTransform>().localPosition.x + panelSize.x, GetComponent<RectTransform>().localPosition.y);
    }

    void ToOrigin()
    {
        movingTowards = initialPosition;
        //Vector2.MoveTowards(transform.position, targetPosition.transform.position, 0.1f);
        //Debug.Log("exit");
        //GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RectTransform>().localPosition.x - panelSize.x, GetComponent<RectTransform>().localPosition.y);
    }
}

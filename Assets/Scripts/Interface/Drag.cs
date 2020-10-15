using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool isDragging;
    private bool mouseOver;

    public GameObject cases;

    void OnMouseOver()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;

        GameObject nearestObject = searchNearestCase();

        Vector3 directionToTarget = nearestObject.transform.position - this.transform.position;
        float dSqrToTarget = directionToTarget.sqrMagnitude;

        if(dSqrToTarget <= 10f)
        {
            this.transform.position = nearestObject.transform.position;
        }
    }

    void Update()
    {
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

        if (isDragging || mouseOver) {
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, .5f);
        } else {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    GameObject searchNearestCase() {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach(Transform potentialTarget in cases.transform)
        {
            Vector3 directionToTarget = potentialTarget.position - this.transform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget.gameObject;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    private bool isDragging;
    private bool mouseOver;

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
}

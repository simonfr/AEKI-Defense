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

        if (nearestObject != null)
        {
            float distanceToTarget = Distance(nearestObject.transform, transform);
            
            if(distanceToTarget <= 1f)
            {
                transform.position = nearestObject.transform.position;
            }
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
            float distanceToTarget = Distance(potentialTarget, transform);

            if(distanceToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = distanceToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget == null ? null : bestTarget.gameObject;
    }

    static float Distance(Transform target, Transform current)
    {
        return Vector2.Distance(target.position, current.position);
    }
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRegionBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyBehavior>() == null)
        return;

        //TODO : Enlever une vie
        GameObject.Destroy(col.gameObject);
    }

}

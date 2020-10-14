using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public List<GameObject> prefabFawling;
    public float frequence = 2;
    public float startSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", frequence, frequence);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        GameObject newObject = Instantiate(prefabFawling[Random.Range(0, prefabFawling.Count)]);
        newObject.transform.position = transform.position;
        newObject.GetComponent<Rigidbody2D>().AddForce(newObject.transform.right * startSpeed);
    }
}

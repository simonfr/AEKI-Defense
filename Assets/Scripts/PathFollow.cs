
  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    Node [] PathNode;
    public GameObject Player;
    public float MoveSpeed;
    float Timer;
    int CurrentNode;
    static Vector3 CurrentPositionHolder;

    // Start is called before the first frame update
    void Start()
    {
        PathNode = GetComponentsInChildren<Node> ();
        CheckNode ();
    }

    void CheckNode(){
        Timer = 0;
        CurrentPositionHolder = PathNode [CurrentNode].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * MoveSpeed;
        if(Player.transform.position != CurrentPositionHolder)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, CurrentPositionHolder, Timer);
        } else {
            if(CurrentNode < PathNode.Length -1) {
                CurrentNode ++;
                CheckNode();
            }
        }

    }
}


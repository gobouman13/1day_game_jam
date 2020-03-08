using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Pathfinding;
using UnityEngine;

public class MobMoving : MonoBehaviour
{
    public int mobMoveMode;

    public  MobSpawn Manager;

    public GameObject Player;

    public Transform target;

    public float avoidInterval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mobMoveMode == 1)
        {
            ChangeAvoidPos();
        }
    }

    public void MoveTargetChange()
    {
        switch (mobMoveMode)
        {
            case 0:
                gameObject.GetComponent<AIDestinationSetter>().target = Player.transform;
                break;
            case 1:
                bool chk = false;
                Vector3 pos=new Vector3();
                Vector2 ans= new Vector2();

                while (!chk)
                {
                    float distanse = Random.Range(7f, 5f);
                    float degree = Random.Range(0f, 360f);
                    pos = new Vector3(Mathf.Sin(Mathf.Deg2Rad*degree),Mathf.Cos(Mathf.Deg2Rad*degree))*distanse;
                    ans = pos;
                    if (Mathf.Abs(pos.x)<37f&&Mathf.Abs(pos.y)<37f) chk = true;
                }

                target.transform.position = ans;
                gameObject.GetComponent<AIDestinationSetter>().target = target.transform;
                break;
        }
    }

    void ChangeAvoidPos()
    {
        bool chk = false;
        Vector3 pos=new Vector3();
        Vector2 ans= new Vector2();

        while (!chk)
        {
            float distanse = Random.Range(7f, 5f);
            float degree = Random.Range(0f, 360f);
            pos = new Vector3(Mathf.Sin(Mathf.Deg2Rad*degree),Mathf.Cos(Mathf.Deg2Rad*degree))*distanse;
            ans = pos;
            if (Mathf.Abs(pos.x)<37f&&Mathf.Abs(pos.y)<37f) chk = true;
        }

        target.transform.position = ans;
        gameObject.GetComponent<AIDestinationSetter>().target = target.transform;
    }
    
}

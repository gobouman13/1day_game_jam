using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobSpawn : MonoBehaviour
{
    [SerializeField] private GameObject MobBase;
    [SerializeField] private GameObject Player;

    [SerializeField] private Vector3[] spawnPoints;

    [SerializeField] private int firstMobNum;

    [SerializeField] private GameObject MobGroup;

    [SerializeField] private float spawnMobInterval;
    
    private GameObject obj;

    float nowSpawnMobInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FirstSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMob()
    {
        bool chk = false;
        Vector3 pos=new Vector3();

        while (!chk)
        {
            float distanse = Random.Range(7f, 5f);
            float degree = Random.Range(0f, 360f);
            pos = new Vector3(Mathf.Sin(Mathf.Deg2Rad*degree),Mathf.Cos(Mathf.Deg2Rad*degree))*distanse;
            Vector2 ans = pos;
            if (Mathf.Abs(pos.x)<37f&&Mathf.Abs(pos.y)<37f) chk = true;
        }
        obj = Instantiate(MobBase, pos, Quaternion.identity);
        obj.GetComponent<AIDestinationSetter>().target = Player.transform;
        obj.transform.parent = MobGroup.transform;        
        obj.GetComponent<MobMoving>().Manager = this;
    }

    IEnumerator FirstSpawn()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < firstMobNum; i++)
        {
            SpawnMob();
            Debug.Log("OK");
            yield return new WaitForSeconds(spawnMobInterval);
        }
        
    }

    public void ChangeMobMode(int mode)
    {
        foreach(Transform childObj in MobGroup.transform)
        {
            childObj.gameObject.GetComponent<MobMoving>().mobMoveMode = mode;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            float distanse = Random.Range(700f, 500f);
            float degree = Random.Range(0f, 360f);
            pos = new Vector3(Mathf.Sin(Mathf.Deg2Rad*degree),Mathf.Cos(Mathf.Deg2Rad*degree))*distanse;
            Vector2 ans = pos;
            if (Mathf.Abs(pos.x)<37f&&Mathf.Abs(pos.y)<37f) chk = true;
        }
        obj = Instantiate(MobBase, pos, Quaternion.identity);
//        obj.GetComponent<AIDestinationSetter>().target = Player.transform;
    }

    IEnumerator FirstSpawn()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < firstMobNum; i++)
        {
            SpawnMob();
            yield return new WaitForSeconds(spawnMobInterval);
        }
        
    }
}

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
    }
}

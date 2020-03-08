using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	GameSystem gameSystem;
	MobSpawn mobSpawn;
	
    void Start()
    {
		gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
		mobSpawn = GameObject.Find("MobSpawn").GetComponent<MobSpawn>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Mob"){
			gameSystem.killCount++;
			Destroy(col.gameObject);
			mobSpawn.SpawnMob();
			mobSpawn.SpawnMob();
			mobSpawn.SpawnMob();
		}
	}
}

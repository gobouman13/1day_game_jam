using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
	GameSystem gameSystem;

	
    void Start()
    {
		gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "Mob"){
			gameSystem.killCount++;
			Destroy(col.gameObject);
		}
	}
}

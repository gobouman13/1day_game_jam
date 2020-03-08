using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	float angle,direction;
	float weaponDirection;

	bool frozen;

    // Start is called before the first frame update
    void Start()
    {
        speed=100;
		frozen = false;
    }

    // Update is called once per frame
    void Update()
    {
		PlayerMove();
		PlayerRotation();
        PlayerAtk();
    }


	void PlayerMove()
	{
        if(!frozen){
			float x = Input.GetAxis("Horizontal");
			float y = Input.GetAxis("Vertical");
			GetComponent<Rigidbody2D>().velocity = new Vector2(x * speed * Time.deltaTime, y * speed * Time.deltaTime);
		}else GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	}

	void PlayerRotation()
	{
        if(!frozen){
			var screenPos = Camera.main.WorldToScreenPoint( transform.position );
			var dir = Input.mousePosition - screenPos;
			angle = GetAim( Vector3.zero, dir);
			transform.GetChild(0).transform.rotation = Quaternion.Euler(0,0,angle - 90);
		}
	}

	void PlayerAtk()
	{
        if (Input.GetKeyDown(KeyCode.Z) && !frozen){
			StartCoroutine(MoveWeapon());
		}
	}

	public IEnumerator MoveWeapon()
    {
        transform.GetChild(1).gameObject.SetActive(true);
		frozen = true;
		weaponDirection = 60;
		for(int i = 0;i < 15;i++){
			transform.GetChild(1).transform.rotation = Quaternion.Euler(0,0,angle + weaponDirection - 90);
			weaponDirection -= 8;
			yield return new WaitForSeconds(0.01f);
		}
        transform.GetChild(1).gameObject.SetActive(false);
		frozen = false;
    }

    public float GetAim( Vector2 from, Vector2 to )
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
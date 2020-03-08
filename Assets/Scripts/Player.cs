using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	float angle,direction;
    // Start is called before the first frame update
    void Start()
    {
        speed=100;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
	void PlayerMove()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(x * speed * Time.deltaTime, y * speed * Time.deltaTime);

        var screenPos = Camera.main.WorldToScreenPoint( transform.position );
        var dir = Input.mousePosition - screenPos;
        angle = GetAim( Vector3.zero, dir);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(0,0,angle + 90);
	}

    public float GetAim( Vector2 from, Vector2 to )
    {
        float dx = to.x - from.x;
        float dy = to.y - from.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
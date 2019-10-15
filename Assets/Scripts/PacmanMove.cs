using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{	
	public float speed = 0.4f;
	Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        // dest = transform.position;
        transform.Translate(dest);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move closer to the destination
        Vector2 p = Vector2.MoveTowards(transform.position,dest,speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for Input if not moving
        if((Vector2)transform.position == dest){
        	if(Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
        	dest = ((Vector2)transform.position + Vector2.up);
        	if(Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
        	dest = ((Vector2)transform.position + Vector2.right);
        	if(Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
        	dest = ((Vector2)transform.position - Vector2.up);
        	if(Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
        	dest = ((Vector2)transform.position - Vector2.right);
        }
    }

    bool valid(Vector2 dir){
    	// Cast a line from 'next to Pacman' to 'Pacman'
    	Vector2 pos = transform.position;
    	RaycastHit2D hit = Physics2D.Linecast(pos+dir,pos);
    	return (hit.collider == GetComponent<Collider2D>());
    }
}

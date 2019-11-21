using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{	
    public Transform[] waypoints;
	int cur=0;

	public float speed = 0.3f;
    
    void FixedUpdate(){
    	// Waypoint not reached yet? then move closer
    	if(transform.position!=waypoints[cur].position){
    		Vector2 p = Vector2.MoveTowards(transform.position,waypoints[cur].position,speed);
    		GetComponent<Rigidbody2D>().MovePosition(p);
    	}
    	else{
    		cur=(cur+1) % waypoints.Length;
    	}

    	Vector2 dir = waypoints[cur].position - transform.position;
    	GetComponent<Animator>().SetFloat("DirX",dir.x);
    	GetComponent<Animator>().SetFloat("DirY",dir.y);
    	
    }

    void OnTriggerEnter2D(Collider2D co){
    	if(co.name == "pacman"){
    		Destroy(co.gameObject);
            GameObject blinky = GameObject.Find("blinky");
            GameObject inky = GameObject.Find("inky");
            GameObject clyde = GameObject.Find("clyde");
            GameObject pinky = GameObject.Find("pinky");
            blinky.GetComponent<GhostMove>().speed = 0.0f;
            inky.GetComponent<GhostMove>().speed = 0.0f;
            clyde.GetComponent<GhostMove>().speed = 0.0f;
            pinky.GetComponent<GhostMove>().speed = 0.0f; 
            GameObject maincamera = GameObject.Find("Main Camera");
            AudioSource bgMusic = maincamera.GetComponent<AudioSource>();
            AudioSource deathMusic = blinky.GetComponent<AudioSource>();
            bgMusic.Stop();
            deathMusic.Play();
       	}
    }
}

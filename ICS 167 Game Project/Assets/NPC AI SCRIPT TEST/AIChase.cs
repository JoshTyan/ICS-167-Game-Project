using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculates distance between object and player object to follow
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //get two positions and move game object towards player game object
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}

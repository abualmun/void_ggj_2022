using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class beeAi : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    
    //use the garafix file name in "enemyGFX" to flip the enemy while chasing... #add it in the bottom 
    public Transform enrmyGFX;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath" ,0f, .5f);
        
    }
    void UpdatePath() 
    {
        if (seeker.IsDone())
         seeker.StartPath(rb.position, target.position, OnpathComplete);

    }
    void OnpathComplete (Path p)
    {
        if (!p.error)
        {
           
            path = p;
            currentWayPoint = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
     if (path == null)
     return;

     if (currentWayPoint >= path.vectorPath.Count){
         reachedEndOfPath = true;
         return;
     } else{
         reachedEndOfPath = false;
     }
     Vector2 direction = ((Vector2) path.vectorPath[ currentWayPoint]- rb.position).normalized;
     Vector2 force = direction * speed * Time.deltaTime;
     rb.AddForce(force);

     float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

    if (distance < nextWayPointDistance){
        currentWayPoint++;

    }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public Transform target;
    public float range;
    bool Detected = false ;
    Vector2 Direction ;
    public GameObject alarm;

    public GameObject Laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPosition = target.position;
        Direction =     targetPosition - (Vector2) transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction,range);
        if(rayInfo.collider.gameObject.tag =="")
        {
            if(Detected == false)
            {
                Detected = true;
                Debug.Log("something got detected ");
            }
        }
        else
        {
            Detected = false;
        }
        if(Detected){
            Laser.transform.up = Direction;
        }
    }
    // thi fun use to see the range
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, range);
    }
}

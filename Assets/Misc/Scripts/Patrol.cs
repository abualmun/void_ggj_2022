using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add it to any GameObject and give it children to patrol between them
/// </summary>
public class Patrol : MonoBehaviour {

    public float speed;
    public float threshold;

    List<Vector2> points;

    private Vector2 point {
        get { return points[index % points.Count]; }
    }

    private Vector2 nextPoint {
        get { return points[(index + 1) % points.Count]; }
    }

    private int index = 0;

    void Start() {
        foreach (Transform child in transform.Find("patrol")) {
            points.Add(child.position);
        }
    }


    void Update() {
        if (Vector2.Distance(transform.position, nextPoint) < threshold) {
            transform.position = Vector2.MoveTowards(transform.position, nextPoint, speed);
        } else {
            index++;
        }
    }
}

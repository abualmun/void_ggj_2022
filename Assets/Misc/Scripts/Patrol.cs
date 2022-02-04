using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add it to any GameObject and give it children to patrol between them
/// </summary>
public class Patrol : MonoBehaviour {

    List<Vector2> points;

    void Start() {
        foreach (Transform child in transform.Find("patrol")) {
            points.Add(child.position);
        }
    }


    void Update() {

    }
}

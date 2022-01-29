using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollower : MonoBehaviour {

    public Vector3 offset;
    private Transform player;

    void Start() {
        player = Player.player.transform;
    }


    void LateUpdate() {
        transform.position = player.position + (Vector3)offset;
    }
}

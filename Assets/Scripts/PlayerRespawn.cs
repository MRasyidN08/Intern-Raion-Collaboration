using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerRespawn : MonoBehaviour
// {
//     private Transform currentCheckpoint;
//     private LifeCount health;

//     private void Awake(){
//         health = GetComponent<LifeCount>();
//     }

//     public void Respawn(){
//         transform.position = currentCheckpoint.position;
//         health.Respawn();
//     }

//     private void OnTriggerEnter2D(Collider2D collision){
//         if(collision.transform.tag == "Checkpoint"){
//             currentCheckpoint = collision.transform;
//             collision.GetComponent<Collider2D>().enabled = false;
//         }
//     }
// }

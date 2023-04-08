using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Looping : MonoBehaviour
{
    [SerializeField] RawImage img;
    private float x, y;
    PlayerMovement player;

    void Update()
    {
        x = player.myRigidbody.velocity.x / 100;
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime, img.uvRect.size);
    }
}

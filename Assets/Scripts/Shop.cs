using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key E Pressed.....");
            SceneManager.LoadScene(1);
        }
    }
}

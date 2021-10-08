using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    //particle effect to be used
    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision) {

        //test if the trigger works
        Debug.Log("Something");

        //instantiate/show the particle effect
        Instantiate(reward, transform.position, transform.rotation);

        //destroy the original game object
        Destroy(gameObject); 
    }
}

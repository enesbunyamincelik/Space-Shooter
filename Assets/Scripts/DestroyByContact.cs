using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerShipExplosion;
    
    private GameController gameController;

    private void Start() 
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerShipExplosion, other.transform.position, other.transform.rotation); // Player Ship Exploion
            gameController.GameOver();
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
        gameController.UpdateScore();
    }
}   
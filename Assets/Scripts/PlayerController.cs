using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    Rigidbody physic;
    AudioSource audioPlayer;

    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;
    
    public Boundary boundary;
    public GameObject shot;
    public GameObject shotSpawn;

    void Start() 
    {
        physic = GetComponent<Rigidbody>();   
        audioPlayer = GetComponent<AudioSource>();     
    }

    void Update()
    {   
        // && = and
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot,shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play();
        }
    }
    void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");    

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = movement * speed;
        
        Vector3 position = new Vector3(
        Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax),
        0,
        Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)
        );

        physic.position = position;

        physic.rotation = Quaternion.Euler(0,0, physic.velocity.x * tilt);
        
    }
}
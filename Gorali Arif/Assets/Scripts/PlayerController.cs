using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody hareket;
    AudioSource audioPlayer;

    [SerializeField] int hiz;
    [SerializeField] int egim;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;
    public float xMin, xMax, zMin, zMax;

    public GameObject isin;
    public GameObject isinspawn;
    
     void Start()
    {
        hareket = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(isin, isinspawn.transform.position, isinspawn.transform.rotation);
            audioPlayer.Play();
        }
           

    }
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 vektor = new Vector3(moveHorizontal, 0, moveVertical);
        hareket.velocity = vektor*hiz;


        Vector3 gemisiniri = new Vector3(Mathf.Clamp(hareket.position.x,xMin,xMax),0,Mathf.Clamp(hareket.position.z,zMin,zMax));
        hareket.position = gemisiniri;

        hareket.rotation = Quaternion.Euler(0,0,hareket.velocity.x*egim);
    
    }
}

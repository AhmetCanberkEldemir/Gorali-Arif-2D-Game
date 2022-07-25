using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    Rigidbody fizik;
    [SerializeField] int hiz;
    // Start is called before the first frame update
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        //float moverVertical = Input.GetAxis("Vertical");

        // Vector3 vector = new Vector3(0, 0, moverVertical);
        fizik.velocity = transform.forward * hiz;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

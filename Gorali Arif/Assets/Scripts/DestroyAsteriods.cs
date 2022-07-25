using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteriods : MonoBehaviour
{
    public GameObject patlama;
    public GameObject gemipatlama;

    public GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sinir")
        {
            return;
        }
         Instantiate(patlama, transform.position, transform.rotation);
            if(other.tag == "Player")
            {
                Instantiate(gemipatlama, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        gameController.UpdateScore();

        }
        
    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject engel;
    public int spawnCount;
    public float spawnWait;
    public float startWait;
    public float whileWait;
    public Text skor;
    public int scoresayac;
    public Text GameOverText;
    public Text RestartText;
    public Text quitText;

    private bool gameOver;
    private bool restart;


    void Update()
    {
        if(restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Application.Quit();
            }
        }     
    }
    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(engel, spawnPosition, spawnRotation);
                /*Coroutine
                 1.IEnumerator döndürmek zorundadır.
                 2.En az 1 adet "yield" ifadesi bulundurmak zorundadır.
                 3.Coroutinler StartCoroutine ifadesiyle çağrılmak zorundadır.*/
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(whileWait);
           
            if(gameOver == true)
            {
                RestartText.text = "Tekrar Oynamak İçin 'R'ye Basınız.";
                quitText.text = "Çıkış için 'E' Tuşuna Basınız.";
                restart = true;
                break;
            }
        }
    }
    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;
    }

    void Start()
    {
        GameOverText.text = "";
        RestartText.text = "";
        quitText.text = "";

        gameOver = false;
        restart = false;
        StartCoroutine(SpawnValues());
    }
    public void UpdateScore()
    {
        scoresayac += 10;
        skor.text = "Skor: " + scoresayac;
    }
}

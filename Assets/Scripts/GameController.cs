using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;
    public int score;


    private bool gameOver;
    private bool restart;

    IEnumerator SpawnValues()
    {      
        yield return new WaitForSeconds(startSpawn);
        while(true) // Altta bulunan kodların her zaman çalıştırılmasını sağlar.
        {
            for(int i = 0; i < spawnCount; i++)
            {   
                Vector3 spawnPosition = new Vector3(Random.Range(-3,3), 0, 10);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(obstacle, spawnPosition, spawnRotation);

                // Coroutine
                // 1. `IEnumerator` döndürmek zorundadır.
                // 2. En az bir adet `yield` ifadesi bulunmak zorundadır.
                // 3. Coroutine'ler çağrılırken mutlaka StartCoroutine() metoduyla çağrılmalıdır.
                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver == true)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    void Update() 
    {
        if(restart == true) 
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Start()
    {   
        gameOverText.text = "";
        restartText.text = "";
        gameOver = false;
        restart = false;

        StartCoroutine(SpawnValues());
    }
}
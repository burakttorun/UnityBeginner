using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject opponentPlayerPrefab;
    public GameObject opponentCaptainPrefab;

    private float spawnRangeX = 30;
    private float spawnZMin = 17; // set min spawn Z
    private float spawnZMax = 27; // set max spawn Z

    public int enemyCount;
    public int waveCount = 1;

    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    AudioClip clapSound;
    [SerializeField]
    AudioClip booSound;
    AudioSource audioSource;
    [SerializeField]
    TextMeshProUGUI gameOverText;
    [SerializeField]
    Button restartButton;
    [SerializeField]
    Text countdownTextField;
    float score;
    float time=90f;
   public bool isGameActive;

    private void Awake()
    {
        StartCoroutine(CountdownCoroutine()); 
    }
    private void Start()
    {
        isGameActive = false;
        SpawnEnemyWave(waveCount);
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isGameActive)
        {
            //Takes the number of enemies on the scene.
            enemyCount = GameObject.FindGameObjectsWithTag("OpponentTeamPlayer").Length;

            //If the number of enemies on the scene is 0, create a new wave.
            if (enemyCount == 0)
            {
                SpawnEnemyWave(waveCount);
            }

            if (isGameActive)
            {
                time -= Time.deltaTime;
                UpdateTimer(time);
            }

            if (time <= 0)
            {
                GameOver();
            }
        }
    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < waveCount; i++)
        {
            Instantiate(opponentPlayerPrefab, GenerateSpawnPosition(), opponentPlayerPrefab.transform.rotation);
            if (i % 3 == 0)
            {
                Instantiate(opponentCaptainPrefab, GenerateSpawnPosition(), opponentCaptainPrefab.transform.rotation);
            }
        }
        waveCount++;
    }
    //Creating counter for time.
    public void UpdateTimer(float totalSeconds)
    {
        int seconds = Mathf.RoundToInt(totalSeconds);
        timeText.text = seconds.ToString();
    }
    //The method that increases 6 points when the ball is delivered to a teammate, and decreases 6 points when the opponent grabs.
    public void MakeScore(int goalValue)
    {
        if (goalValue < 0)
        {
            audioSource.PlayOneShot(booSound);
        }
        else
        {
            audioSource.PlayOneShot(clapSound);
        }
        score += goalValue;
        scoreText.text = score.ToString();
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Countdown to "set", "hut" and "go" at game start.
    IEnumerator CountdownCoroutine()
    {
        countdownTextField.text = "Set!";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "Hut!";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "GO!!!";
        
        // start the game here
        yield return new WaitForSeconds(1.0f);
        countdownTextField.gameObject.SetActive(false);
        isGameActive = true;
        yield return null;
    }
}

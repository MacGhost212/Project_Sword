using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform startPoint;

    public float timeBetweenWaves = 7f;
    private float countdown = 4f;

    public Text waveCountDownText;

    private int waveIndex = 1;

    public GameManager gameManager;

    void Update()
    {
        if(EnemiesAlive >0)
        {
            return;
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        Debug.Log("Wave Incoming!");
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            Debug.Log("Level Won");
            this.enabled = false;
        }

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, startPoint.position, startPoint.rotation);
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public int waveNumber = 1;
    public int enemyCount;

    private float spawnRange = 4; //enemy spawns in random position

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
       enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

       if(enemyCount == 0){
        waveNumber++;
        SpawnEnemyWave(waveNumber);
       }
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for(int i=0; i<enemiesToSpawn;i++){

            //spawn range chooses random number for x and z position
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-spawnRange, spawnRange);
            Vector3 randomPos = new Vector3(spawnPosX, 2, spawnPosZ);  

            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
        }

    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sean
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        public GameObject RandomEnemy => enemyList.Count==0? null:enemyList[Random.Range(0, enemyList.Count)];
        public int WaveNumber => waveNumber;
        public float TimeBetweenWaves => timeBetweenWaves;


        [SerializeField] bool spawnEnemy=true;
        [SerializeField] GameObject[] enemyPrefabs;
        [SerializeField] float timeBetweenSpawns = 1f;

       [SerializeField] float timeBetweenWaves = 1f;
       [SerializeField] int minEnemyAmount=4;
       [SerializeField] int maxEnemyAmount=10;
        [SerializeField] WaveUI waveUIController;
        [SerializeField] Transform defaultEnemySpawnPoint;
        int waveNumber = 1;
        int enemyAmount;

        List<GameObject> enemyList;
        protected override void Awake()
        {
            base.Awake();
            enemyList = new List<GameObject>();
        }
        private IEnumerator Start()
        {

            while (spawnEnemy)
            {
                yield return new WaitUntil(() => enemyList.Count == 0);

                waveUIController.OpenOrCloseWaveUI(true);
                yield return new WaitForSeconds(timeBetweenWaves);
                waveUIController.OpenOrCloseWaveUI(false);
                yield return  RandomlySpawnCo();
                
        }
            }
        IEnumerator RandomlySpawnCo()
        {
            enemyAmount = Mathf.Clamp(enemyAmount,minEnemyAmount+waveNumber/3,maxEnemyAmount);
           
                for (int i = 0; i < enemyAmount; i++)
                {
                    var _enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                    enemyList.Add(PoolManager.Release(_enemy,defaultEnemySpawnPoint.position));
                    yield return new WaitForSeconds(timeBetweenSpawns);
                }
            
            waveNumber++;
           
        }
        public void RemoveFromList(GameObject _enemy)
        {
            if (enemyList.Contains(_enemy))
            {
                enemyList.Remove(_enemy);
            }
        }
    }
}
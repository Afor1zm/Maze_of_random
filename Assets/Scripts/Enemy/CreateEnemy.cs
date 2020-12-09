using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private List<MazeCell> freeCell = new List<MazeCell>();
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject mazeGenerator;
    [SerializeField] private PlayerEvents playerEvents;
    private GameObject enemyObject;
    private MazeCell randomSpawnCell;
    private Vector3 spawnPosition;
    private Vector3 patrolPosition;
    private MazeCell randomPatrolCell;

    private void Start()
    {        
        freeCell = mazeGenerator.GetComponent<MazeGenerator>().emptyCells;
        InstantiateEnemy(2);
    }

    private void InstantiateEnemy(int enemyCount)
    {
        for(int i = 0; i < enemyCount; i++)
        {            
            randomSpawnCell = freeCell[Random.Range(3,freeCell.Count-2)];
            spawnPosition = new Vector3(randomSpawnCell.PositionX, -0.2659531f, randomSpawnCell.PositionY);
            enemyObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            randomPatrolCell = freeCell[Random.Range(3, freeCell.Count - 2)];
            patrolPosition = new Vector3(randomPatrolCell.PositionX, -0.2659531f, randomPatrolCell.PositionY);
            enemyObject.GetComponent<EnemyPatrol>().SetPatrolCell(patrolPosition);
            enemyObject.GetComponent<EnemyListener>().PlayerEvents = playerEvents;
        }        
    }
}

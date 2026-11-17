using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private int _enemyCount = 5;

    [SerializeField]
    private Transform spawnPointTop1, spawnPointTop2,
        spawnPointBottom1,
        spawnPointBottom2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = SelectRandomPosition();
        GameObject enemyObject = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Enemy spawned at: " + spawnPosition);

        EnemyMove enemy = enemyObject.GetComponent<EnemyMove>();
        if (enemy != null)
        {
            enemy.OnDie += SpawnEnemy;
        }
    }

    private Vector3 SelectRandomPosition()
    {
        Transform selectedTransform = null;
        int randomValue = Random.Range(0, 4);
        SpawnPointType spawnType = (SpawnPointType)randomValue;
        switch(spawnType)
        {
            case SpawnPointType.TopLeft:
                selectedTransform = spawnPointTop1;
                break;
            case SpawnPointType.TopRight:
                selectedTransform = spawnPointTop2;
                break;
            case SpawnPointType.BottomLeft:
                selectedTransform = spawnPointBottom1;
                break;
            case SpawnPointType.BottomRight:
                selectedTransform = spawnPointBottom2;
                break;
        }

        Debug.Log(
            "Selected: " + selectedTransform.name +
            " | Position: " + selectedTransform.position
        );

        return selectedTransform.position + (Vector3)Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum SpawnPointType
{
    TopLeft = 0,
    TopRight = 1,
    BottomLeft = 2,
    BottomRight = 3
}
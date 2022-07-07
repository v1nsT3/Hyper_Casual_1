using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Creature _prefabCreature;
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
    [SerializeField] private Transform _creatureContainer;

    [SerializeField] private int _poolCount = 20;
    [SerializeField] private bool _autoExpand = false;

    private PoolMono<Creature> _pool;

    // Start is called before the first frame update
    void Start()
    {
        _pool = new PoolMono<Creature>(_prefabCreature, _poolCount, _creatureContainer);
        _pool.AutoExpand = _autoExpand;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            CreatureSpawn();
            yield return null;
        }
    }

    private void CreatureSpawn()
    {
        int rnd = (int)Random.Range(0, _spawnPoints.Count - 1f);
        var creature = _pool.GetFreeElement();
        creature.transform.position = _spawnPoints[rnd].transform.position;
        creature.transform.rotation = _spawnPoints[rnd].transform.rotation;
        creature.AddForce(_spawnPoints[rnd].minAngle, _spawnPoints[rnd].maxAngle);
    }
}

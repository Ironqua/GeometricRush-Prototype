using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static Test instance;
    [SerializeField] GameObject[] _chunks;
    [SerializeField] private float _chunkLength = 54f;
    [SerializeField] private Transform _playerTransform;
    //[SerializeField] private float _spawnDistance = 50f;
    [Header("Pool Config")]
    [SerializeField] private int _size = 10;

    private List<Queue<GameObject>> _chunksQueueList = new List<Queue<GameObject>>();
    private Dictionary<GameObject, Queue<GameObject>> _chunkToQueueMap = new Dictionary<GameObject, Queue<GameObject>>();
    private Vector3 _spawnPos = new Vector3(0f, 0f, 10f);

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PoolChunks();
        SpawnRandomChunk();
    }

   

    private void PoolChunks()
    {
        for (int i = 0; i < _chunks.Length; i++)
        {
            Queue<GameObject> newPool = new Queue<GameObject>();
            for (int j = 0; j < _size; j++)
            {
                GameObject newObj = Instantiate(_chunks[i].gameObject);
                newObj.SetActive(false);
                newPool.Enqueue(newObj);
                _chunkToQueueMap[newObj] = newPool;
            }
            _chunksQueueList.Add(newPool);
        }
    }

    public void SpawnRandomChunk()
    {
        if (_chunksQueueList.Count == 0)
            return;

        int randomIndex = Random.Range(0, _chunksQueueList.Count);
        Queue<GameObject> selectedQueue = _chunksQueueList[randomIndex];

        if (selectedQueue.Count == 0)
            return;

        GameObject newChunk = selectedQueue.Dequeue();
        newChunk.transform.position = _spawnPos;
        _spawnPos.z += _chunkLength;
        newChunk.SetActive(true);

       
        StartCoroutine(DeactivateAndEnqueue(newChunk, 30f));
    }

    IEnumerator DeactivateAndEnqueue(GameObject chunk, float delay)
    {
        yield return new WaitForSeconds(delay);
        chunk.SetActive(false);

        
        if (_chunkToQueueMap.ContainsKey(chunk))
        {
            _chunkToQueueMap[chunk].Enqueue(chunk);
        }
    }
}

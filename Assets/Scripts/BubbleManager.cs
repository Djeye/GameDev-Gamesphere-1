using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private float spawnRate;
    [SerializeField, Range(0, 1)] private float activeArea;

    private float _delayTime;
    private float _timeToSpawn;
    private Camera _camera;

    public event Action ClickOnBubble;

    void Start()
    {
        _camera = Camera.main;
        _delayTime = 1 / spawnRate;
        _timeToSpawn = _delayTime;
    }

    public void TriggerEvent()
    {
        ClickOnBubble?.Invoke();
    }

    void Update()
    {
        if (Time.time > _timeToSpawn)
        {
            Instantiate(bubble, SpawnPosition(), SpawnRotation(), transform);
            _timeToSpawn = Time.time + _delayTime;
        }
    }

    private Vector2 SpawnPosition()
    {
        var side = _camera.orthographicSize * activeArea;
        return new Vector2(Random.Range(-side, side), Random.Range(-side, side));
    }

    private Quaternion SpawnRotation()
    {
        return Quaternion.Euler(0f, 0f, Random.Range(0.0f, 90.0f));
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpikeGenerator : MonoBehaviour
{
    public float MinSpeed => _minSpeed;
    public float MaxSpeed => _maxSpeed;
    public float CurrentSpeed => _currentSpeed;
    public float SpeedMultiplier => _speedMultiplier;
    
    [SerializeField] private SpikePool spikePool;
    [FormerlySerializedAs("MinSpeed")] [SerializeField] private float _minSpeed;
    [FormerlySerializedAs("MaxSpeed")] [SerializeField] private float _maxSpeed;
    [FormerlySerializedAs("currentSpeed")] [SerializeField] private float _currentSpeed;
    [FormerlySerializedAs("SpeedMultiplier")] [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _minSpanwTime;
    [SerializeField] private float _maxSpawnTime;

    private List<ObstaclesClass> _obstacles;
    private float _nextSpawnTime;

    private void Awake()
    {
        _obstacles = new List<ObstaclesClass>();
        _currentSpeed = _minSpeed;
    }

    public void generateObstacle(ObstaclesClass oldSpike)
    {
        if (oldSpike)
        {
            _obstacles.Remove(oldSpike);
            spikePool?.ReturnObject(oldSpike);
        }

        if (spikePool != null)
        {
            ObstaclesClass SpikeIns = spikePool.GetObject();
            if (SpikeIns != null)
            {
                SpikeIns.transform.position = transform.position;
                SpikeIns.transform.rotation = transform.rotation;
                _obstacles.Add(SpikeIns);
            }
        }
    }


    private void UpdateNextSpanwTime()
    {
        _nextSpawnTime = Time.time + Random.Range(_minSpanwTime, _maxSpawnTime);
    }

    private void Update()
    {   if(_nextSpawnTime < Time.time)
        {
            generateObstacle(null);
            UpdateNextSpanwTime();
        }
        ChangeSpeed();
    }

    public void RemoveObstacle(ObstaclesClass oldSpike)
    {
        if (oldSpike)
        {
            _obstacles.Remove(oldSpike);
            spikePool.ReturnObject(oldSpike);
        }
    }

    private void ChangeSpeed()
    {
        if (_currentSpeed > _maxSpeed)
            return;
        
        _currentSpeed += _speedMultiplier;
        
        for (int spikeIndex = 0; spikeIndex < _obstacles.Count; spikeIndex++)
            _obstacles[spikeIndex].NotifySpeedChange(_currentSpeed);
    }
}
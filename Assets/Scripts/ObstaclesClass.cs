using UnityEngine;

public class ObstaclesClass : MonoBehaviour
{
    private float _currentSpeed;
    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void NotifySpeedChange(float speed)
    {
        _currentSpeed = speed;
    }

    private void Update()
    {
        rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }
}
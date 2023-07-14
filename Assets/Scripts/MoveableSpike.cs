using UnityEngine;
using System.Collections;

public class MoveableSpike : ObstaclesClass
{
    private float _targetYVelocity;
    [SerializeField] private float lowerBound = 1f;
    [SerializeField] private float upperBound = 2f;
    [SerializeField] private float smoothTime = 0F;
    private float  _nextDirectionChange;

    // Update is called once per frame
    protected override void OnUpdate()
    {

        if (Time.time > _nextDirectionChange)
        {
            ChangeDirectionOverTime();
        }
       ClampPositionToBounds();      
    }

    private void ChangeDirectionOverTime()
    {
        _nextDirectionChange = Time.time + Random.Range(0.5f, 1f);
        rb.velocity = new Vector2(rb.velocity.x, Random.Range(-0.7f, 0.7f));
    }

    private void ClampPositionToBounds()
    {
        Vector2 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, lowerBound, upperBound);
        transform.position = clampedPosition;
        if (rb.position.y == lowerBound)
        {
            rb.velocity = new Vector2(rb.velocity.x, 2f);
        }
        else if (rb.position.y == upperBound)
        {
            rb.velocity = new Vector2(rb.velocity.x, -2f);
        }
    }

}
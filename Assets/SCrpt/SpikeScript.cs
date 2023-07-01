using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour
{
    private float _currentSpeed;
    private bool _movingUp = true;
    private Rigidbody2D rb;
    private float _targetYVelocity;
    public float lowerBound = 0.8f;
    public float upperBound = 5f;
    public float smoothTime = 1F;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void NotifySpeedChange(float speed)
    {
        _currentSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);

        if (this.tag == "ship")
        {
            StartCoroutine(MoveShip());

            if (transform.position.y < lowerBound)
            {
                transform.position = new Vector2(transform.position.x, lowerBound);
                rb.velocity = new Vector2(rb.velocity.x, 0); // Stop the ship from moving downwards
            }
            else if (transform.position.y > upperBound)
            {
                transform.position = new Vector2(transform.position.x, upperBound);
                rb.velocity = new Vector2(rb.velocity.x, 0); // Stop the ship from moving upwards
            }

            // Smoothly adjust the vertical velocity
            float newVelocityY = Mathf.Lerp(rb.velocity.y, _targetYVelocity, smoothTime);
            rb.velocity = new Vector2(rb.velocity.x, newVelocityY);
        }




    }
    IEnumerator MoveShip()
    {
        _targetYVelocity = Random.Range(0, 2) == 0 ? -3f : 3f;
        yield return new WaitForSeconds(4f);

    }
}







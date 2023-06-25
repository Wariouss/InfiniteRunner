using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private float _currentSpeed;

    public void NotifySpeedChange(float speed)
    {
        _currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (_currentSpeed * Time.deltaTime));
    }
}








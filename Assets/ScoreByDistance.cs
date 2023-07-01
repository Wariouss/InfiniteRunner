using UnityEngine;
using UnityEngine.UI;

public class ScoreByDistance : MonoBehaviour
{
    public float score = 0;

    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTravelled = Vector3.Distance(transform.position, lastPosition);

        // if distance travelled is more than or equal to 1, increment the score
        if (distanceTravelled >= 1)
        {
            score += Mathf.Floor(distanceTravelled); // Add only whole meters to the score
            lastPosition = transform.position; // Update the last position to the current
            
            
        }
    }
}

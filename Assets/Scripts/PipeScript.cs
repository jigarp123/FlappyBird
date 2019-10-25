using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour
{
    public float scrollSpeed;
    public float newX, newY;
    private float min = -1f, max = 0.65f;

    void Start()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, Random.Range(min, max));
    }
    void Update()
    {
        newX = transform.localPosition.x - (Time.deltaTime * scrollSpeed);
        newY = transform.localPosition.y;
        if (newX <= -1.7f)
        {
            newX = 2.8f;
            newY = Random.Range(min, max);
        }
        transform.localPosition = new Vector2(newX, newY);
    }
}

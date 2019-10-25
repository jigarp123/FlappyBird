using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour
{
    public float scrollSpeed;
    private float newX, newY;

    void Start()
    {
    }
    void Update()
    {
        newX = transform.localPosition.x - (Time.deltaTime * scrollSpeed);
        if (newX <= -2.9)
        {
            newX = 5.626f;
        }
        transform.localPosition = new Vector2(newX, transform.localPosition.y);
    }
    void FixedUpdate()
    {
    }
}

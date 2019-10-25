using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour
{
    public float scrollSpeed;
    private float newX, newY;

    void Start()
    {
    }
    void Update()
    {
        newX = transform.localPosition.x - (Time.deltaTime * scrollSpeed);
        if (newX <= -3.86f)
        {
            newX = 2.39f;
        }
        transform.localPosition = new Vector2(newX, transform.localPosition.y);
    }
    void FixedUpdate()
    {
    }
}

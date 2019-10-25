using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
 using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine.Analytics;



public class BirdScript : MonoBehaviour
{
    public float thrust;
    public GameObject interfaceObject;
    public GameObject floor;
    public bool isDead;
    public bool isPaused;
    private float newY;
     int totalPotions = 5;
int totalCoins = 100;
string weaponID = "Weapon_102";

    void Start()
    {Analytics.CustomEvent("gameOver", new Dictionary<string, object>
  {
    { "potions", totalPotions },
    { "coins", totalCoins },
    { "activeWeapon", weaponID }
  });
        interfaceObject.GetComponent<InterfaceScript>().Quit();
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        floor.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    void Update()
    {
        if (!isDead)
        {
            newY = transform.position.y;
            if (interfaceObject.transform.Find("Main").gameObject.activeInHierarchy)
            {
                newY = (Mathf.Sin(Time.time * 5f) * 0.1f) + 1.25f;
            }
            else
            {
                if (!isPaused)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                    {
                        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                        GetComponent<Rigidbody2D>().AddForce(Vector3.up * thrust);
                        newY = transform.position.y;
                        if (Random.Range(0, 2) < 1)
                        {
                            GetComponents<AudioSource>()[0].Play();
                        }
                        else
                        {
                            GetComponents<AudioSource>()[3].Play();
                        }
                    }
                }
            }
            transform.localPosition = new Vector3(-0.5f, newY, 0);
        }
        else
        {
            interfaceObject.GetComponent<InterfaceScript>().Dead();
            if (GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
    void FixedUpdate()
    {
        if (!interfaceObject.transform.Find("Main").gameObject.activeInHierarchy)
        {
            if (GetComponent<Rigidbody2D>().velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 30, GetComponent<Rigidbody2D>().velocity.y / 2));
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -80), Time.deltaTime * (float)(-3.5 * GetComponent<Rigidbody2D>().velocity.y));
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!isDead && !col.gameObject.name.Equals("Ceiling"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            isDead = true;
            GetComponent<Animator>().SetBool("isDead", true);
            GetComponents<AudioSource>()[1].Play();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead)
        {
            interfaceObject.GetComponent<InterfaceScript>().score++;
            GetComponents<AudioSource>()[2].Play();
        }
    }
}
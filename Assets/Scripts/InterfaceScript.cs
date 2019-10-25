using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InterfaceScript : MonoBehaviour
{
    public GameObject player;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject floor1;
    public GameObject floor2;
    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject pipe3;
    public int score;
    private int bestScore;

	void Start()
    {
        score = 0;
        bestScore = PlayerPrefs.GetInt("BestScore");
    }
	void Update()
    {
        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", score);
        }
        transform.Find("Playing").transform.Find("Score").GetComponent<Text>().text = "" + score;
    }
    public void Play()
    {
        DisableAll();
        Reset();
        transform.Find("Playing").gameObject.SetActive(true);
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    public void Pause()
    {
        DisableAll();
        transform.Find("Paused").gameObject.SetActive(true);
        transform.Find("Paused").transform.Find("Score").GetComponent<Text>().text = score + "";
        player.GetComponent<Animator>().SetBool("isDead", true);
        player.GetComponent<BirdScript>().isPaused = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        background1.GetComponent<BackgroundScript>().scrollSpeed = 0f;
        background2.GetComponent<BackgroundScript>().scrollSpeed = 0f;
        background3.GetComponent<BackgroundScript>().scrollSpeed = 0f;
        floor1.GetComponent<FloorScript>().scrollSpeed = 0f;
        floor2.GetComponent<FloorScript>().scrollSpeed = 0f;
        pipe1.GetComponent<PipeScript>().scrollSpeed = 0f;
        pipe2.GetComponent<PipeScript>().scrollSpeed = 0f;
        pipe3.GetComponent<PipeScript>().scrollSpeed = 0f;

    }
    public void Unpause()
    {
        DisableAll();
        transform.Find("Playing").gameObject.SetActive(true);
        player.GetComponent<Animator>().SetBool("isDead", false);
        player.GetComponent<BirdScript>().isPaused = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        background1.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        background2.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        background3.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        floor1.GetComponent<FloorScript>().scrollSpeed = 1.1f;
        floor2.GetComponent<FloorScript>().scrollSpeed = 1.1f;
        pipe1.GetComponent<PipeScript>().scrollSpeed = 1.1f;
        pipe2.GetComponent<PipeScript>().scrollSpeed = 1.1f;
        pipe3.GetComponent<PipeScript>().scrollSpeed = 1.1f;
    }
    public void Quit()
    {
        DisableAll();
        score = 0;
        player.GetComponent<Animator>().SetBool("isDead", false);
        transform.Find("Main").gameObject.SetActive(true);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        player.GetComponent<BirdScript>().isDead = false;
        player.GetComponent<BirdScript>().isPaused = false;
        background1.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        background2.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        background3.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        floor1.GetComponent<FloorScript>().scrollSpeed = 1.1f;
        floor2.GetComponent<FloorScript>().scrollSpeed = 1.1f;
        pipe1.GetComponent<PipeScript>().scrollSpeed = 0f;
        pipe2.GetComponent<PipeScript>().scrollSpeed = 0f;
        pipe3.GetComponent<PipeScript>().scrollSpeed = 0f;
        pipe1.transform.position = new Vector2(2f, Random.Range(-1f, 0.65f));
        pipe2.transform.position = new Vector2(3.5f, Random.Range(-1f, 0.65f));
        pipe3.transform.position = new Vector2(5f, Random.Range(-1f, 0.65f));
    }
    private void DisableAll()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    private void Reset()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<BirdScript>().isDead = false;
        player.GetComponent<Animator>().SetBool("isDead", false);
        player.GetComponent<BirdScript>().isPaused = false;
        player.transform.position = new Vector2(-0.5f, 1.25f);
        score = 0;
        background1.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        background2.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        background3.GetComponent<BackgroundScript>().scrollSpeed = 0.2f;
        pipe1.transform.position = new Vector2(2f, Random.Range(-1f, 0.65f));
        pipe2.transform.position = new Vector2(3.5f, Random.Range(-1f, 0.65f));
        pipe3.transform.position = new Vector2(5f, Random.Range(-1f, 0.65f));
        floor1.GetComponent<FloorScript>().scrollSpeed = 1.1f;
        floor2.GetComponent<FloorScript>().scrollSpeed = 1.1f;
        pipe1.GetComponent<PipeScript>().scrollSpeed = 1.1f;
        pipe2.GetComponent<PipeScript>().scrollSpeed = 1.1f;
        pipe3.GetComponent<PipeScript>().scrollSpeed = 1.1f;
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
    public void Dead()
    {
        DisableAll();
        transform.Find("Dead").gameObject.SetActive(true);
        transform.Find("Dead").transform.Find("HighScore").GetComponent<Text>().text = "Best Score: " + bestScore;
        transform.Find("Dead").transform.Find("Score").GetComponent<Text>().text = score + "";
        player.GetComponent<BirdScript>().isPaused = false;
        player.GetComponent<Animator>().SetBool("isDead", true);
        background1.GetComponent<BackgroundScript>().scrollSpeed = 0f;
        background2.GetComponent<BackgroundScript>().scrollSpeed = 0f;
        background3.GetComponent<BackgroundScript>().scrollSpeed = 0f;
        floor1.GetComponent<FloorScript>().scrollSpeed = 0f;
        floor2.GetComponent<FloorScript>().scrollSpeed = 0f;
        pipe1.GetComponent<PipeScript>().scrollSpeed = 0f;
        pipe2.GetComponent<PipeScript>().scrollSpeed = 0f;
        pipe3.GetComponent<PipeScript>().scrollSpeed = 0f;
    }
}

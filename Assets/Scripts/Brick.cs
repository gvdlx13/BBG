using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    private int timesHit;                                   // Use this for initialization
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private bool isBreakable;

    void Start () {
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D ( Collision2D col)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }


    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            ProduceSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void ProduceSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
    }
    void LoadSprites()
    {
        if (hitSprites[timesHit])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
        }
    }

    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}


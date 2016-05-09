using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    
    private float distance;
    private float startTime;

    private GameManager gameManager;
    private int level;

    void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        level = PlayerPrefs.GetInt("Level");
    }

    void Update()
    {
        // bullet shoot
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // if shoot success
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                // if enemy not die
                Transform healthBarTransform = target.transform.FindChild("HealthBar");
                HealthBar healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                // if enemy die
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    gameManager.ShowDestroyAnimation(target.transform.position, 0.35F);
                    AudioSource audioSource = target.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                    gameManager.Score += (30 + 2*level);
                    gameManager.Gold += (50 + 3*level);
                }
            }
            Destroy(gameObject);
        }
    }
}

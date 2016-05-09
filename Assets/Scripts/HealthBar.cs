using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;
    private float originalScale;

    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
        int level = PlayerPrefs.GetInt("Level");
        float healthFactor = 5 + level;
        healthFactor /= 5;
        maxHealth *= healthFactor;
        currentHealth *= healthFactor;
    }

    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}

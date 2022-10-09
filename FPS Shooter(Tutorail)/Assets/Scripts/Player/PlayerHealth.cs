using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{   
    [Header("Health Bar")]
    public float maxHealth = 100f;
    [SerializeField] private Text healthText;

    [Header("Damage Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;
    private float health;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    public void UpdateHealthUI()
    {
        healthText.text = System.Convert.ToString(health);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.6f);
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
    }

    // Update is called once per frame
    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (overlay.color.a > 0)
        {
            if (health < 30)
                return;

            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }
}

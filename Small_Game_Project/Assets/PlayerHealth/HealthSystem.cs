using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentHealth { get; private set; }
    public int maxHealth = 3;
    public TextMeshProUGUI CountText;
    void Start()
    {
        currentHealth = maxHealth;
        CountText.text = string.Format("{0:n0}", currentHealth);
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        CountText.text = string.Format("{0:n0}", currentHealth);
        if (currentHealth <= 0)
        {
            //game over screen
            //player controls freeze
            //UI should appear
            Destroy(gameObject);

        }
    }
}

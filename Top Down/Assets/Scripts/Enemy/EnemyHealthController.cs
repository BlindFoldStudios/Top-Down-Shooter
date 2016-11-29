using UnityEngine;
using System.Collections;

public class EnemyHealthController : MonoBehaviour {

    public int health;
    private int currentHealth;

	void Start () {
        currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(currentHealth <= 0)
        {
            Destroy(gameObject);

        }
	}

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;

    }
}

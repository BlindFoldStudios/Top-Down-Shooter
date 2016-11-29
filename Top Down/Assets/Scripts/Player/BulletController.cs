using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public int damageToGive ;



    public GameObject bulletPrefab;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);       //Moves the bullet forward. 

        lifeTime -= Time.deltaTime;  //Counts Down.

        if(lifeTime <= 0)
        {
            Destroy(gameObject);  //Destroy bullet after "certain" time.
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealthController>().HurtEnemy(damageToGive);   //Calls the HurtEnemy Function, and gives damage to enemy.
            Destroy(gameObject);   //Makes sure that the enemy is not pushed back, by destroying it.

        }


    }

     
    
}

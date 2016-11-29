using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public bool isFiring;

    public PlayerNoiseOutput _PlayerNoiseOutput;

    public Transform NoisePoint;

    public BulletController bullet;
    public float bulletSpeed;

    public GameObject bulletPrefab;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;


    IEnumerator bulletWait(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        
    }


    void Update()
    {
        if (isFiring)
        {           

            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController; //Intializes bullet
                newBullet.speed = bulletSpeed;
            }

        }else
        {
            shotCounter = 0;          
        }


    }

    

}

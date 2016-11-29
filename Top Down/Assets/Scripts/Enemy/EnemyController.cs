using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float moveSpeed;

  void Update()
    {
        transform.Translate(new Vector3(0, 0, moveSpeed) * Time.deltaTime);
    }

    void OnCollisonEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Point")
        {
            moveSpeed = -5;
        }
    }

}

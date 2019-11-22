using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision != null)
        {
            Debug.Log(collision.name);
            player.DamagePlayer(1);
            Debug.Log("PLAYER HIT YO");
            Destroy(gameObject);
        }
    }


    // Update is called once per frame

}

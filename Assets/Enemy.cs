using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
public class Enemy : MonoBehaviour
{
    public bool switchState = false;
    public float gameTimer;
    public int seconds = 0;
    public StateMachine<Enemy> stateMachine { get; set; }

    public int health;
    public int walkspeed;
    public GameObject player;
    public bool range;
    float MoveSpeed = 3f;
    public float dist;
    public SpriteRenderer render;
    public Transform EnemyFirePoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<Enemy>(this);
        stateMachine.ChangeState(FirstState.Instance);
        gameTimer = Time.time;

        health = 75;
        render = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>gameTimer+1)
        {
            gameTimer = Time.time;
            seconds++;
            Debug.Log(seconds);
        }
        if(seconds==5)
        {
            seconds = 0;
            switchState = !switchState;
        }

        stateMachine.Update();


        
        if (health == 1)
            render.color = new Color(255, 0, 0);
        if (health == 0)
            Destroy(this.gameObject);

        GameObject search = GameObject.FindGameObjectWithTag("Player");
        if (search != null)
        {
            transform.LookAt(search.transform);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            dist = Vector3.Distance(transform.position, search.transform.position);

            if (dist < 10)
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }

        if (Input.GetKeyDown("1"))
        {
            shoot();
        }

    }

    void shoot()
    {
        Debug.Log("enemyshooting");
        Instantiate(bulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
    }
}
    


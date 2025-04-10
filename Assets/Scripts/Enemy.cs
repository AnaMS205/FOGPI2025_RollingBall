using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speedRange = 2.0f;

    private Rigidbody enemyRB;
    private GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //decide readom speed
        float speed = Random.Range(0.2f, speedRange);
        //find player and move twords loaction
        enemyRB.AddForce((player.transform.position - transform.position).normalized * speed);

        //destroy enemy if they fall off the cliff
        if(transform.position.y < -5){
            Destroy(gameObject);
        }
    }
}

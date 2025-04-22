using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;

    float speed = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //find player and move twords loaction
        enemyRB.AddForce((player.transform.position - transform.position).normalized * speed);

        //destroy enemy if they fall off the cliff
        if(transform.position.y < -5){
            ScoreManager.instance.AddPoints(3);
            Destroy(gameObject);
        }
    }
}

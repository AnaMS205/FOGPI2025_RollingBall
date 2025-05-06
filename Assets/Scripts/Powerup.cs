using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject player;
    private float powerUpStrength = 15.0f;
    private bool powerUpRunning = false;
    private bool useable;
    public TMP_Text status;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUp.SetActive(false);
        useable = true;
        status.text = "PowerUp Ready!";
        
    }

    // Update is called once per frame
    void Update()
    {
        powerUp.transform.position = player.transform.position;

        if(Input.GetKey("space") && useable == true){
                PowerUpActive();
        }
        
    }

    private void PowerUpActive(){
        powerUpRunning = true;
        powerUp.SetActive(true);
        //yield return new WaitForSeconds(2);
        //Debug.Log("the powerup is active");

        //add here find colsest enemy and go twords (check enemy posision.y >= 1 )
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && powerUpRunning == true){

            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 goAway = (collision.gameObject.transform.position - transform.position);

            enemyRB.AddForce(goAway * powerUpStrength, ForceMode.Impulse);
            //powerUpActive = false;
            
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown(){
        yield return new WaitForSeconds(1);
        powerUpRunning = false;
        useable = false;
        powerUp.SetActive(false);
        status.text = "PowerUp in Cooldown...";
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown(){
        yield return new WaitForSeconds(3);
        useable = true;
        status.text = "PowerUp Ready!";
        StartCoroutine(BlinkingText());
    }


    IEnumerator BlinkingText(){
        for(int i = 0; i>=3; i++){
            status.enabled = !status.enabled;
            yield return new WaitForSeconds(0.5f);
        }

    }

}

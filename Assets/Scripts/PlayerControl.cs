using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    //public float verticalInput;
    //public float horizontalInput;

    public int lives = 3;

    public TMP_Text livesText;
    public TMP_Text deathScreen;
    //public TMP_Text deathScreen;

    public int score = 0; //score = waves cleared * time 
    
    private Rigidbody playerRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        livesText.text = "Lives : " + lives.ToString();   
        playerRB = GetComponent<Rigidbody>();
        //deathScreen.text = "";

    }

    // Update is called once per frame
    void Update()
    {
            float verticalInput = Input.GetAxis("Vertical"); //get inputs
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
            //it's done this way so the player actually rolls instend of sliding
            playerRB.AddForce(movement * speed);

        //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput); 
        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput); 

            if(transform.position.y < -5){  //handle falling
                lives --;
                if(lives == 0){
                        //death and stop game
                        //show score on death screen
                        //stop game time
                DeathScreen();
                }
                Respawn();

            }

               // while(lives > 0){
            

        //once lives < 0
        //HandleDeath();

    }

    void Respawn(){
        Vector3 respawnPosition = new Vector3(0,1,0);
        //stop player from rolling after respawn
        playerRB.linearVelocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
        transform.position = respawnPosition;
        livesText.text = "Lives : " + lives.ToString();
    }

    void DeathScreen(){
        deathScreen.text = "YOU DIED";
        Time.timeScale = 0;
    }
   
}

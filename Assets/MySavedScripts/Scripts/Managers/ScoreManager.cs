using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    //ScoreManager.instance.AddPoints();    //add any instance of score manager
    public static ScoreManager instance{ get; private set;}

    public float score {get; private set;}
    public float multiplyer{get; private set;}

    public UnityEvent<ScoreInfo> updateScore;
    void Awake()    //called before start
    {
        if (instance == null){
            
            instance = this;
        }else{
            //instance.score = 0; //reset score
            Destroy(this);  //if second insance, destroy the instance
            return;
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void AddPoints(float _amount, Vector3? _location = null){
        score += _amount;

        updateScore.Invoke(new ScoreInfo(score, multiplyer, _amount, _location ));
        
    }

    public class ScoreInfo{
        public float score;
        public float multiplyer;
        public float delta;
        public Vector3? location;

        public ScoreInfo(float _score, float _multiplyer, float _delta, Vector3? _location = null){
           //this.score = score; //if underscores weren't used

           score = _score;
           multiplyer = _multiplyer;
           delta = _delta;
           location = _location;
        }
    }
}

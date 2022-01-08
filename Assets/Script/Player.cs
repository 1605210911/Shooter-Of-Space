
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    //  AudioSource backgroundMusic;
    [SerializeField]
    private float _speed =3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]    private GameObject _tripleShot;
   [SerializeField] private float _fireRate= 0.15f;
  
   float _canfire = -1f;
[SerializeField]private int live = 3;
private
SpawnManager _spawnManager;
[SerializeField]
private bool _isTripleshotActive = false;

  powerUpSpawn _powerUpSpawn;
  SpeedUpSpawn _speedUpSpawn;
  SpawnShield _spawnShield;
  [SerializeField] GameObject _shieldVisualizer;
  
    public bool shieldbool = false;
  public bool isShieldActive= false;
  [SerializeField]  private int _Score =0;
  private UIManager _uiManager;
  [SerializeField] GameObject LeftEngine;
  [SerializeField] GameObject RightEngine;
 public bool PlayerLive = true;
 float MinX, MaxX, MinY,MaxY, padding= 0.4f;
    FinalEnemySpawn finalEnemySpawn;
    FinalEnemy finalEnemy;
    public Joystick joystick;
    public bool damageBool;
    float horizontalInput;
    float VerticalInput;
   




    void Start()
    {
        damageBool = true;
        transform.position = new Vector3(0,0,0);
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        
        if(_spawnManager == null){
            Debug.Log("The Spawn Manager is NULL");
        }

        //powerUp = FindObjectOfType(typeof(PowerUp)) as PowerUp;
        _powerUpSpawn = FindObjectOfType(typeof(powerUpSpawn)) as powerUpSpawn;
        _spawnShield  = FindObjectOfType(typeof(SpawnShield)) as SpawnShield;
        _speedUpSpawn = FindObjectOfType(typeof(SpeedUpSpawn)) as SpeedUpSpawn;
        finalEnemy = FindObjectOfType(typeof(FinalEnemy)) as FinalEnemy;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null){
            Debug.Log("UI Manager is null");
            // backgroundMusic.Play();
        }
            // startBoundaries();
            float x =0,y=0;  ;

            Vector2 pos = new Vector2(x,y);
            Camera gameCamera = Camera.main;
           pos=  GetScreenSizeInWorldCoords(gameCamera,10);
          
           MinX = -pos.x/2+padding; MaxX= pos.x/2-padding;
           MinY = -pos.y/2+0.2f; MaxY= pos.y/2;


        finalEnemySpawn = FindObjectOfType(typeof(FinalEnemySpawn)) as FinalEnemySpawn;
    }

   
    void Update()
    {
        CalculateMovement();
        //  if(Input.GetKey(KeyCode.Space)&& Time.time>_canfire){
        //  }
        if(Time.time>_canfire){
             fireLaser();
        }
        
        
        
     
    }
    void CalculateMovement(){
        if (joystick.Horizontal >= .2f)
        {
            horizontalInput = joystick.Horizontal;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            horizontalInput = joystick.Horizontal;
        }
        else horizontalInput = 0;
        if (joystick.Vertical >= 0.2f)
        {
            VerticalInput = joystick.Vertical;
        }
        else if (joystick.Vertical <= -0.2f)
        {
            VerticalInput = joystick.Vertical;
        }
        else
            VerticalInput = 0;
       
        float horizontalInput1 = Input.GetAxis("Horizontal");
       
        float VerticalInput1 = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput,VerticalInput,0);
        Vector3 direction1 = new Vector3(horizontalInput1,VerticalInput1,0);
    transform.Translate(direction*Time.deltaTime*_speed);
    transform.Translate(direction1*Time.deltaTime*_speed);
transform.position = new Vector3(Mathf.Clamp(transform.position.x,MinX,MaxX),Mathf.Clamp(transform.position.y,MinY,MaxY),0);
    }

     public static Vector2 GetScreenSizeInWorldCoords(Camera gameCamera, float distance = 10f)
        {
            float width = 0f;
            float height = 0f;

            if (gameCamera.orthographic)
            {
                if (gameCamera.orthographicSize <= .001f)
                    return Vector2.zero;

                var p1 = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, gameCamera.nearClipPlane));
                var p2 = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, gameCamera.nearClipPlane));
                var p3 = gameCamera.ViewportToWorldPoint(new Vector3(1, 1, gameCamera.nearClipPlane));

                width = (p2 - p1).magnitude;
                height = (p3 - p2).magnitude;
            }
            else
            {
                height = 2.0f * distance * Mathf.Tan(gameCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
                width = height * gameCamera.aspect;
            }

            return new Vector2(width, height);
        }

    // void startBoundaries(){
    //     Camera gameCamera = Camera.main;
    //     MinX = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x;
    //     Debug.Log(MinX);
    //     MaxX = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x;
    //     Debug.Log(MaxX);
    // }
    void fireLaser(){
        if(Input.GetKey("space")||true){
        _canfire =Time.time +_fireRate;
 if(_isTripleshotActive== true){
            
            Instantiate(_tripleShot,transform.position,Quaternion.identity);

        }
        else{
             
           Instantiate(_laserPrefab,transform.position+ new Vector3(0,0.8f,0),Quaternion.identity);
        
        }
        }    
           
    }
    public void Damage(){
        if (damageBool == true)
        {
            if (shieldbool == true)
            {
                return;
            }
            else
            {
                live--;
                _uiManager.UpdateLive(live);
                if (live == 2)
                {
                    RightEngine.SetActive(true);
                }
                else if (live == 1)
                {
                    LeftEngine.SetActive(true);
                }
                else if (live < 1)
                {
                    _spawnManager.OnPlayerDeath();
                    Destroy(this.gameObject);
                    _powerUpSpawn.stopPowerupSpawn();
                    _speedUpSpawn.stopSpeedUp();
                    _spawnShield.StopShieldSpawn();
                }
            }
        }
        
       
    }

private void OnTriggerEnter2D(Collider2D other) {
         if(other.tag == "TripleLaserActive"){
            StartCoroutine(tripleShot());
         }
        if(other.tag == "SpeedUp"){
            StartCoroutine(SpeedUp());
           
        }
        if(other.tag=="Shield"&& isShieldActive== false){
           
            StartCoroutine(shield());
        }
        if(other.tag== "EnemyLaser"){
            Damage();
            shieldDeactivate();
            Destroy(other.gameObject);
        }
         
}
IEnumerator shield(){
    if(isShieldActive == false&&shieldbool==false){
        isShieldActive = true;
    ShieldActivate();
    
        yield return new WaitForSeconds(5f);

    
    shieldDeactivate();
     
    }

}

public void ShieldActivate(){
shieldbool = true;
    _shieldVisualizer.SetActive(true);
}
public void shieldDeactivate(){
    _shieldVisualizer.SetActive(false);
     shieldbool = false;
    isShieldActive = false;
}

IEnumerator SpeedUp(){
 _speed = 7f;
 yield return new WaitForSeconds(5f);
 _speed = 3.5f;
}   


        
    IEnumerator tripleShot(){

         
            _isTripleshotActive = true;
            // powerUp.destroy();
        yield return new WaitForSeconds(5f);
        _isTripleshotActive = false;
        
    }
    public void updateScore(int points){
        _Score += points ;
        _uiManager.updateUI(_Score);
        if (_Score > Random.Range(250,400) && finalEnemy.finalEnemyLive())
        {
            finalEnemySpawn.finalEnemyStart();

        }

    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FinalEnemy : MonoBehaviour
{
    [SerializeField] int enemyPower = 1;
    [SerializeField] float speed = 4;
    Player player;
     Collider2D collider2D;
     
     SpriteRenderer spriteRenderer;
    AudioSource EnemyExplosion;
    // Handle to Animator Component
    Animator _Anim;
  public  bool FinalEnemyLive = true;
  
    [SerializeField] float Period = 2f;
    UIManager uIManager;
    [SerializeField] private Text gameCompleteText;
    [SerializeField] private bool loopBool = true;
    
    
    

    void Start()
    {
       
        player = FindObjectOfType(typeof(Player)) as Player;
        uIManager = FindObjectOfType(typeof(UIManager)) as UIManager;
        collider2D = GetComponent<Collider2D>();
        EnemyExplosion = GetComponent<AudioSource>();
        
        if (player != null)
        {
            if (_Anim = null)
            {
                Debug.LogError("The Animator is null");
            }
            _Anim = GetComponent<Animator>();
        }
        else
            Debug.Log("Player is null");
        gameCompleteText.gameObject.SetActive(false);
        
        spriteRenderer = GetComponent<SpriteRenderer>();
       


    }

    public void Update()
    {
        

        

        if (transform.position.y < 2.5f)
        {
            float cycle = Time.time / Period;
            const float tau = Mathf.PI * 2;
            float RawSineWave = Mathf.Sin(cycle*tau);// Going from -1 to 1;

            transform.Translate(Vector3.left * Time.deltaTime * speed * RawSineWave);




        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
                player.shieldDeactivate();
            }
            FinalEnemyLive = false;

            _Anim.SetTrigger("OnEnemyDeath");
            EnemyExplosion.Play();
            Destroy(transform.GetChild(0).gameObject);
            Destroy(this.gameObject, 2.5f);
            collider2D.enabled = false;
            speed = 0;

        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
           

            if (enemyPower == 0)
            {
                //  StartCoroutine(DoDeleteAll());

                //_Anim.SetTrigger("OnEnemyDeath");

                //EnemyExplosion.Play();
                collider2D.enabled = false;
               

                FinalEnemyLive = false;
                
                Destroy(transform.GetChild(0).gameObject);
                player.damageBool = false;
                speed = 0;
                PlayerPrefs.SetInt("Level1", 1);
                spriteRenderer.enabled = false;
                StartCoroutine(GameCompleteText());
                StartCoroutine(GameOver());

            }
            IEnumerator GameOver()
            {
                yield return new WaitForSeconds(5f);
                Destroy(this.gameObject);

                SceneManager.LoadScene(1);

            }
            IEnumerator GameCompleteText()
            {
                while (loopBool == true)
                {
                    
                    gameCompleteText.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    gameCompleteText.gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.5f);
                }

            }

            enemyPower--;
            if (player != null)
            {
                player.updateScore(10);
            }
        }
    }
    public bool finalEnemyLive()
    {
        return FinalEnemyLive;
    }

}
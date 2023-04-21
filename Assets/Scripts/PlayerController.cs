using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 5;
    public int coinCount;
    public Text coinText;
   public Animator FinnAnim;
   public SpriteRenderer FinnSprite;
   
    // Start is called before the first frame update
   
    void Start()
    {
        FinnAnim = GetComponentInChildren<Animator>();
       // aS = GetComponent<AudioSource>();
      //  FinnSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        FinnAnim.SetFloat("Speed", h);
        FinnSprite.flipX = h < 0;
       // transform.Translate(Vector3.right * h * Time.deltaTime * speed);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 vel = new Vector3();

        vel.x = h * speed;
        vel.y = rb.velocity.y;
        vel.z = 0;

        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce);
            vel.y = jumpForce;

        }
        rb.velocity = vel;

        if (coinCount == 13)
        {
            SceneManager.LoadScene("Victory");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coinCount++;
            SoundManager.instance.PlaySound(0);
            // coinText.text = coinCount.ToString();
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "Barrier")
        {
            SoundManager.instance.PlaySound(1);
            // coinText.text = coinCount.ToString();
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.tag == "Fan")
        {
            SoundManager.instance.PlaySound(1);
            // coinText.text = coinCount.ToString();
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    
public void GoToNewScene()
    {
      
    }
}

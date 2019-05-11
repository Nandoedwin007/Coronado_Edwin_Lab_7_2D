using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamusScript : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float force = 2f;
    private bool hasPowerUp = false;

    private SpriteRenderer samusSprite;

    public Sprite Samus2;

    private BoxCollider2D boxColliderSamus2;
  
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        samusSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            samusSprite.flipX = true;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            samusSprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {

        if (rb2d)
        {
            rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * force, 0))
;       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si toca el Metroid se muere el Player
        if (collision.gameObject.tag == "Mob" && hasPowerUp == false)
        {
            Destroy(gameObject);
        }else if (collision.gameObject.tag == "Mob" && hasPowerUp == true)
        {
            Destroy(collision.gameObject);
        }


            //Si toca el Metroid se muere el Player
            if (collision.gameObject.tag == "PowerUp" && hasPowerUp==false)
        {
            hasPowerUp = true;
            //samusSprite.enabled = false;    
            GetComponent<SpriteRenderer>().sprite = Samus2;
            boxColliderSamus2 = GetComponent<BoxCollider2D>();
            boxColliderSamus2.size = new Vector2(0.28f, 0.43f);
            transform.localScale = new Vector3(8.0f, 8.0f,0f);
        }
    }

    private void Jump()
    {
        if (Mathf.Abs(rb2d.velocity.y) < 0.005f)
        {
            rb2d.AddForce(new Vector2(0, 1.0f * force), ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samus2Script : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float force = 2f;
    private bool hasPowerUp = false;

    private SpriteRenderer samusSprite;

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
;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si toca el Metroid se muere el Player
        if (collision.gameObject.tag == "Mob" && hasPowerUp == false)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Mob" && hasPowerUp == true)
        {
            Destroy(collision.gameObject);
        }


        //Si toca el Metroid se muere el Player
        if (collision.gameObject.tag == "PowerUp" && hasPowerUp == false)
        {
            hasPowerUp = true;
            samusSprite.enabled = true;
            //gameObject.SetActive(false);
            //GetComponent<SpriteRenderer>().sprite = Samus2;
            //transform.localScale = new Vector3(2.0f, 2.0f,0f);
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

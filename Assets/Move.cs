using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var otherthing = collision.gameObject;


        if (otherthing.GetComponent<Enemy>() == null)
            return;

        var renderer = otherthing.GetComponent<SpriteRenderer>();
        renderer.color = new Color(255, 0, 0);

        var scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.PlusOne();



    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = transform.position + Vector3.right * 0.01f;
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = transform.position + Vector3.left * 0.01f;


        if (Input.GetKey(KeyCode.UpArrow))
        {
            var startingPoint = transform.position;
            var collider  = GetComponent<BoxCollider2D>();

            startingPoint.y -= transform.localScale.y / 2;
           // startingPoint.y -= 0.01f;
            var result = Physics2D.Raycast(startingPoint, Vector2.down);
            if (result.collider != null)
            {
                if (result.distance < 0.05f)
                {
                Debug.Log(result.collider.gameObject.name);
                    //transform.position = transform.position + Vector3.up * 0.01f;

                    var rigidBody = GetComponent<Rigidbody2D>();
                    rigidBody.AddForce(Vector2.up, ForceMode2D.Impulse);
                }
            }


        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    private Vector3 movement;
    private float x;
    private float y;
    public float speed;

    public Sprite skinStraight;
    public Sprite skinDiagonal;
    public GameObject skinHolder;
    private SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        sr = skinHolder.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = 0;
        y = 0;
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            y += 1;
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            y += -1;
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            x += -1;
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            x += 1;
        }

        movement = new Vector3(x, y, 0f);
        movement = movement.normalized;
        movement = movement * speed * Time.deltaTime;

        gameObject.transform.position += movement;


        //skin rotation portion
        if (y == 1 && x == 0)
        {
            //straight up
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            sr.sprite = skinStraight;
            sr.flipX = true;
        }
        else if (y == 0 && x == 1)
        {
            //straight right
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
            sr.sprite = skinStraight;
            sr.flipX = true;
        }
        else if (y == -1 && x == 0)
        {
            //straight down
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            sr.sprite = skinStraight;
            sr.flipX = true;
        }
        else if (y == 0 && x == -1)
        {
            //straight left
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            sr.sprite = skinStraight;
            sr.flipX = true;
        }
        else if (y == 1 && x == 1)
        {
            //diagonal top right
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            sr.sprite = skinDiagonal;
            sr.flipX = false;
        }
        else if (y == -1 && x == 1)
        {
            //diagonal bottom right
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
            sr.sprite = skinDiagonal;
            sr.flipX = false;
        }
        else if (y == -1 && x == -1)
        {
            //diagonal bottom left
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            sr.sprite = skinDiagonal;
            sr.flipX = false;
        }
        else if (y == 1 && x == -1)
        {
            //diagonal top left
            skinHolder.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            sr.sprite = skinDiagonal;
            sr.flipX = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    private bool _stopSpawning = false;
    public GameObject _engel1;
    public GameObject _engel2;

    Rigidbody2D rigid;
    Vector3 move;
    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnRoutine());

    } 
    //float mapSpeed=5.0f;
    float characterUpSpeed = 5.0f;
    float horizontalTransformSpeed = 10.0f;

    bool bas = false;
    bool bas2 = false;
    // Update is called once per frame
    bool degdi = false;
    void Update()
    {

        if (!degdi)
        {
            if (Input.GetAxis("Vertical") > 0f)
            {
                bas = true;
            }
            if (bas)
            {
                print("tek bas");
                rigid.AddForce(Vector3.up * characterUpSpeed);
                move = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                bas = false;
                rigid.gravityScale = -9.8f;
                //transform.position += move * characterUpSpeed * Time.deltaTime;
            }
        }



        if (Input.GetAxis("Vertical") < 0f)
        {
            bas2 = true;
        }
        if (bas2)
        {
            rigid.gravityScale = 9.8f;
            rigid.AddForce(Vector3.down * characterUpSpeed);
            move = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            bas2 = false;
            //transform.position += move * characterUpSpeed * Time.deltaTime;
        }


        move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += horizontalTransformSpeed * move * Time.deltaTime;



        //if (Input.GetAxis("Horizontal") > 1f)
        //{
        //    transform.position += move * verticalTransformSpeed * Time.deltaTime;

        //}






        //if(Input.GetAxisRaw("Vertical") == 1)
        //{
        //   rigid.AddForce(new Vector2(0 , 10));
        //   transform.position += move * 10 * Time.deltaTime;
        //}

        //if(Input.GetAxis("Horizontal") >= 0)
        //{

        //}


        /*
        float vertical = verticalTransformSpeed * Input.GetAxis("Vertical");
        Vector2 xEkseni = new Vector2(vertical, 0);
        rigid.AddForce(xEkseni);
        transform.Rotate(vertical,0,0);
        */
        //pozisyon arttýr veya rigidbody addForce

        //anakarakteri siliyor.
        if (transform.position.x<-12.0f)
        {
            Destroy(this.gameObject);
        }


       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "taban")
        {
            //degdi = true;
            print("taban");
            bas = false;
            transform.position = new Vector3(transform.position.x,collision.transform.position.y-0.32f, 0f);
            print(transform.position.x);
            print(collision.transform.position.y - 1);
        }

        if (collision.gameObject.tag == "alttaban")
        {
            print("alttaban");
            bas = false;
            transform.position = new Vector3(transform.position.x, collision.transform.position.y+0.32f, 0f);
            print(transform.position.x);
            print(collision.transform.position.y - 1);
        }
    }


    //GameObject _engel1;
    //IEnumerator SpawnRoutine()
    //{
    //    while (true)
    //    {
    //        Vector3 position = new Vector3(Random.Range(-8f, 8f), 7, 0);
    //        Instantiate(_engel1, position, Quaternion.identity);

    //        yield return new WaitForSeconds(5.0f);
    //    }


    //}
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            
            Vector3 position = new Vector3(13f, -1.51f, 0);
            if (Random.Range(1, 7) <3.5f)
            {
                //Vector3 position = new Vector3(13f, -1.51f, 0);
                Instantiate(_engel1, position, Quaternion.identity);
               // Vector3 position = new Vector3(13f, -1.51f, 0);
            }
            else
            {
                //Vector3 position = new Vector3(13f, 1.79f, 0);
                Instantiate(_engel2, position, Quaternion.identity);
            }
            //GameObject newEngel1 = Instantiate(_engel1, position, Quaternion.identity);
            //newEngel1.transform.parent = _engel1.transform;

            yield return new WaitForSeconds(3.0f);

        }
    }


    //IEnumerator SpawnRoutine()
    //{

    //    while (true)
    //    {
    //        Vector3 position = new Vector3(6f, 0f, 0);
    //        GameObject engel1 = Instantiate(_engel1, position, Quaternion.identity);
    //        yield return new WaitForSeconds(2f);
    //    }
    //}














}

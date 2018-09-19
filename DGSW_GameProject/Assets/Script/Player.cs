using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public UnityEngine.UI.Text point;

    Rigidbody2D rigidbody;
    Animator anim;
    public float jumppower = 5f;
    public Vector3 lookDirection;
    int pointint = 0;
    float time = 0;
    int touch = 1;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("dead", false);
        rigidbody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update () {
        if(!Global.timeup)
            time += Time.deltaTime;

        if (time > 3f)
        {
            Global.timeup = true;
            JumpCheck();
            OutCHeck();
            rigidbody.gravityScale = 1;
        }
        
        point.text = "점수: " + pointint;
    }

    void JumpCheck()
    {
        if ((Input.touchCount>0 && anim.GetBool("dead")==false) || (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("dead")==false))
        {
            Debug.Log("진입");
            rigidbody.velocity = new Vector3(0, 0, 0);
            //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + jumppower, transform.position.z);
            rigidbody.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
        }
        lookDirection.z = rigidbody.velocity.y * 10f + 20f;
        Quaternion R = Quaternion.Euler(lookDirection);
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, R, 5f);
    }

    void OutCHeck()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos; //좌표를 적용한다.
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Something")|| other.gameObject.tag.Equals("Ground")){
            Debug.Log("충돌");
            anim.SetBool("dead", true);
            Global.point = pointint;
        }     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Something"))
        {
            pointint += 1;
            Debug.Log("통과: "+pointint);
        }
    }
}

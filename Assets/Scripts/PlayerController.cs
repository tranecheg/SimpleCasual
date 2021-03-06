using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject goalUp, goalDown, reloadBtn;
    public Text textScore;
    private bool click;
    private float speed = 4f;
    public static int count;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            click = !click;

        if (click)
           transform.position = Vector3.MoveTowards(transform.position, goalUp.transform.position, Time.deltaTime * speed);
        if (!click)
            transform.position = Vector3.MoveTowards(transform.position, goalDown.transform.position, Time.deltaTime * speed);
        if (transform.position == goalUp.transform.position)
            click = false;
        if (transform.position == goalDown.transform.position)
            click = true;
        
        transform.rotation *= Quaternion.Euler(0, 0, 0.3f);


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Goal1")
        {
            score();
            goalDown.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), goalDown.transform.position.y);
            goalDown.SetActive(true);
            goalUp.SetActive(false);
        }
        if (col.tag == "Goal2")
        {
            score();
            goalUp.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), goalUp.transform.position.y);
            goalDown.SetActive(false);
            goalUp.SetActive(true);
        }
        if (col.tag == "Enemy")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<ParticleSystem>().Stop();
            reloadBtn.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
        }
            
    }
    
    void score()
    {
        count++;
        textScore.text = count.ToString();
    }
    public void Reload()
    {
        SceneManager.LoadScene("Main");
    }
}
    

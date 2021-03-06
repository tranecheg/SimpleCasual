using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject spawn;
    void Update()
    {
        spawn = GameObject.Find("SpawnEnemy");
        if (spawn.transform.position.x == 4)
            LeftMove();
        else
            RightMove();
        
    }

    void LeftMove()
    {
        transform.rotation *= Quaternion.Euler(0, 0, -0.5f);
        transform.position -= new Vector3(2.5f * Time.deltaTime, 0, 0);
        if (transform.position.x < -4)
            Destroy(gameObject);
    }
    void RightMove()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 0.5f);
        transform.position += new Vector3(2.5f * Time.deltaTime, 0, 0);
        if (transform.position.x > 4)
            Destroy(gameObject);
    }
}

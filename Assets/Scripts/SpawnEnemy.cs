using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject pref;
    private float wait = 1.5f;

    void Start()
    {
        StartCoroutine(enemySpawn());
        PlayerController.count = 0;
    }

    IEnumerator enemySpawn()
    {
        while (true)
        {
            if (PlayerController.count % 5 == 0)
                transform.position = new Vector2(4, 0);

            if (PlayerController.count % 10 == 0)
                transform.position = new Vector2(-4, 0);

            Instantiate(pref, new Vector2(transform.position.x, Random.Range(-1.5f, 1.5f)), Quaternion.identity);
            yield return new WaitForSeconds(wait);
        }
    }
    
}

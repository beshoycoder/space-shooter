using System.Collections;
using UnityEngine;

public class CreatingAstroids : MonoBehaviour
{
    [SerializeField]
    private enemy_scriptable[] enemies;

    [SerializeField]
    private Transform[] spawner;

    [SerializeField]
    private int speed;

    private void Start()
    {
        StartCoroutine(spawnenemies());
        //Creation();
        //StartCoroutine(CreationTime());
    }

    //private void Creation()
    //{
    //    if (gameObject.tag == "LeftUp")
    //    {
    //        Position = Instantiate(enemies[0].prefab, transform.position, transform.localRotation);
    //        Position.transform.localScale = new Vector3(1, 1, 1);
    //        Debug.Log(transform.position);
    //    }
    //    else if (gameObject.tag == "RightUp")
    //    {
    //        Position = Instantiate(enemies[0].prefab, transform.position, transform.localRotation);
    //        Position.transform.localScale = new Vector3(1, 1, 1);
    //    }
    //    else if (gameObject.tag == "Up")
    //    {
    //        Position = Instantiate(enemies[0].prefab, transform.position, transform.localRotation);
    //        Position.transform.localScale = new Vector3(1, 1, 1);
    //    }
    //}

    //private IEnumerator CreationTime()
    //{
    //    yield return new WaitForSeconds(2);
    //    Creation();
    //    StartCoroutine(CreationTime());
    //}
    private IEnumerator spawnenemies()
    {
        int enemy_no =Random.Range(0,enemies.Length);
        int spawner_no =Random.Range(0,spawner.Length);
        GameObject enemyy = Instantiate(enemies[enemy_no].prefab, spawner[spawner_no].position, spawner[spawner_no].localRotation);
        yield return new WaitForSeconds(2);
        StartCoroutine(spawnenemies());
    }
}
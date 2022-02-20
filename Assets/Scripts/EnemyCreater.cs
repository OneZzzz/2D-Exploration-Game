using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    private GameObject enemy;
    public float force =300;

    private void Start()
    {
        enemy = Resources.Load<GameObject>("enemy");
        StartCoroutine(CreaterEnemy());
    }

    IEnumerator CreaterEnemy()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(4, 9));
            if (UIManager.isInDiaState)
                continue;
            Vector3 creatPos = GetEnemyCreatPosition();
            GameObject go= Instantiate(enemy, transform);
            go.transform.position = creatPos;
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        }
    }
    private Vector3 GetEnemyCreatPosition()
    {
        Camera ca = Camera.main;
        Vector3 screenPosition = new Vector3(Screen.width*1.1f, Screen.height / 2);
        Vector3 targetVector3=  ca.ScreenToWorldPoint(screenPosition);
        targetVector3 = new Vector3(targetVector3.x, PlayerController.instance.transform.position.y, 0);
        return targetVector3;
    }
}

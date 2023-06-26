using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;


    public int totalShotBullet;
    public int totalEnemyKilled;

    private int enemyKilled = 0;
    private int shotBullet = 0;


    void Start()
    {
        print("hello world");
    }
    void Awake()
    {
        if(Instance == null)
        {
            print("Here this");
            Instance = this;
        } else {
            print("Destroy it");
            Destroy(gameObject);
            return;
        }
        print("Before dont destryo");
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ShotBullet{
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET : " + shotBullet.ToString();
        }
    }

    public int EnemyKilled{
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED : " + enemyKilled.ToString();
        }
    }

}

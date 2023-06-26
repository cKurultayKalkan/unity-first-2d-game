using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;


    public int totalShotBullet;
    public int totalEnemyKilled;

    private int enemyKilled = 0;
    private int shotBullet = 0;
    EasyFileSave myFile;

    void Start()
    {
        print("hello world");
    }
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            StartProcess();
        } else {
            Destroy(gameObject);
            return;
        }
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

    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();

    }

    public void SaveData()
    {

        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;
        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);
        myFile.Save();
    }

    public void LoadData()
    {
        if (myFile.Load()) {

            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }
}

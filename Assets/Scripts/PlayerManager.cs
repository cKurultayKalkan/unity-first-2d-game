using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed; 
    public Transform bullet, floatingText, bloodParticle;
    bool dead = false;
    Transform muzzle;
    public Slider slider;
    bool mouseIsNotOverUI;


    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.ShotBullet = 0;
        DataManager.Instance.EnemyKilled = 0; 
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
        
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

        if((health - damage) >= 0){
            health -= damage;
        } else {
            health = 0;
        }

        slider.value = health;

        AmIDead();

    }

    void AmIDead(){
        if(health <= 0){
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            dead = true;
            DataManager.Instance.LoseProcess();
            Destroy(gameObject);
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataManager.Instance.ShotBullet++;
    }
}

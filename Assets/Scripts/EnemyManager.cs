using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    bool colliderBusy = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     print("Collider alanına gird: " + other.name);

     if(other.tag == "Player" && !colliderBusy){
        colliderBusy = true;
        other.GetComponent<PlayerManager>().GetDamage(damage);

     }  

     if(other.tag == "Bullet"){
        colliderBusy = true;
        GetDamage(other.GetComponent<BulletManager>().bulletDamage);
        Destroy(other.gameObject);
     }    

    }

    void OnTriggerStay2D(Collider2D other)
    {
    }

    void onTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && colliderBusy){
            colliderBusy = false;
        }   
    }

    public void GetDamage(float damage)
    {

        if((health - damage) >= 0){
            health -= damage;
        } else {
            health = 0;
        }
        
        AmIDead();
    }

    void AmIDead(){
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}

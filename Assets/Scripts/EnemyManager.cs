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

    }

    void OnTriggerStay2D(Collider2D other)
    {
        print("Collider alanında: " + other.name);
    }

    void onTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player" && colliderBusy){
            colliderBusy = false;
        }   
        print("Collider Alanından çıktı: " + other.name);
    }
}

using UnityEngine;
using System.Collections;
using System;

public class playerSystem : MonoBehaviour {

    bool isAlive;
    int currentHealth;
    int maxHealth;
    int armour;
    int currentEnergy;
    int maxEnergy;
    int speed;
    float jumpStrength;

    PlayerClass pClass;

    Weapon weap;
    public ArrayList weaponList;

    Item item;


    // Use this for initialization
    void Start () {

        //Hook this to class stats after classes added
        maxHealth = 100;
        maxEnergy = 100;
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        armour = 0;
        speed = 50;
        jumpStrength = 10.0f;
	}

    public void applyDamage(int damage)
    {
        currentHealth -= damage-armour;
        if(currentHealth <= 0)
        {
            kill();
        }
    }

    public void heal(int i)
    {
        currentHealth += i;
    }

    public void addEnergy(int i)
    {
        currentHealth += i;
    }

    public void useEnergy(int i)
    {
        currentEnergy -= i;
    }

    public void addArmour(int i)
    {
        armour += i;
    }


    public void breakArmour(int i)
    {
        armour -= i;
    }


    void kill()
    {
        Console.WriteLine("Player killed. Oops.");
        respawn();
        //TO DO
        //Death and clean up
    }

    void respawn()
    {
        maxHealth = 100;
        maxEnergy = 100;
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        armour = 0;
        speed = 50;
        jumpStrength = 10.0f;

        transform.position = new Vector3(0,0,0);
    }

    public bool getVitals()
    {
        return isAlive;
    }

    public int getEnergy()
    {
        return currentEnergy;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getSpeed()
    {
        return speed;
    }

    public float getJumpStrength()
    {
        return jumpStrength;
    }

    public PlayerClass getPlayerClass()
    {
        return pClass;
    }

    public Weapon getWeap()
    {
        return weap;
    }

    public Item getItem()
    {
        return item;
    }

    // Update is called once per frame
    void Update () {
	
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class MyFirstScript : MonoBehaviour
{
    private bool isAlive;
    [SerializeField] private int age;
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private double gravity;
    [SerializeField] private string characterName;
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 scalingDir;
    [SerializeField] private float scalingVelocity;
    [SerializeField] private Vector3 rotationDir;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject house;

    [SerializeField] private Bullet bulletPrefab;

    private void Awake()
    {
        Debug.Log("Awake");
        Shoot();
    }

    private void Start()
    {
        Debug.Log("Start");
        Hello();
    }

    private void Update()
    {
        Move();
        CheckDead();
        Debug.Log("Update");
        UpdateHouse();
    }

    private void UpdateHouse()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ActivateHouse(true);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            ActivateHouse(false);
        }
    }

    private void Hello()
    {
        Debug.Log("Hello" + GetInfo());
    }

    private string GetInfo()
    {
        string info;
        info = characterName;
        info = info + age;
        return info;
    }

    private void ComplexOperation()
    {
        int number = 5;
        number += 2;
        number *= 3;
    }

    private void Heal(float healAmount)
    {
        health += healAmount;
        bool hasMaxHealth = health == maxHealth;
        bool hasHealthMissing = health != maxHealth;
    }

    private void HasSpecialName()
    {
        bool hasSpecialName = characterName == "George";
        bool hasRegularName = characterName != "George";
    }

    private void HasSpecialAbility()
    {
        //Si el personaje se llama George o Jorge, es especial
        // bool hasGeorgeName = characterName == "George";
        // bool hasJorgeName = characterName == "Jorge";
        bool hasSpecialName = characterName == "George" || characterName == "Jorge";
        bool hasSpecialAbility = hasSpecialName && isAlive;
    }

    private void CheckDead()
    {
        /*
        voy a chequear que el personaje tenga mas que 0 de vida
        */

        isAlive = health > 0;
        bool isDead = !isAlive;

        //Imprimir un mensaje de que el personaje esta vivo

        // if (isAlive)
        // {
        //     Debug.Log("It's alive");
        // }
        // else
        // {
        //     Debug.Log("It's dead");
        // }

        //Si el personaje esta vivo, imprimo el mensaje It's alive
        //Si el personaje no esta vivo Y tiene una velocidad mayor a 0, pongo su velocidad en 0
        //Si el personaje no esta vivo y su velocidad es <= 0, imprimo que esta completamente muerto

        if (isAlive)
        {
            Debug.Log("It's alive");
        }

        else if (speed > 0)
        {
            speed = 0;
        }
        else
        {
            Debug.Log("It's dead");
        }

        if (!isAlive && speed > 0)
        {
            speed = 0;
        }

        else
        {
            Debug.Log("It's dead");
        }
    }

    private void Move()
    {
        //Si esta vivo Y la velocidad es mayor a 0, entonces se mueve

        if (isAlive && speed > 0)
        {
            transform.Translate(movementDirection * speed);
            transform.localScale += scalingDir * scalingVelocity;
            transform.Rotate(rotationDir, rotationSpeed);
        }
    }

    private void Shoot()
    {
        //Hacer aparecer un prefab de bala
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        //Moverlo
    }


    private void ActivateHouse(bool isActive)
    {
        house.SetActive(isActive);
    }
}
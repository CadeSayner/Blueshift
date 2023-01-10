using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Defines the bullet object
public class Bullet
{
    public Action<Bullet> OnBulletSpawnedCb;
    public Action<Bullet> cbOnChanged;
    public float X
    {

        get { return Mathf.Lerp(currPosition.x, targetPosition.x, Movementpercentge); }
        // Mathf.Lerp() Interpolates between two floats by a given float
    }

    public float Y
    {
        get { return Mathf.Lerp(currPosition.y, targetPosition.y, Movementpercentge); }

    }

    float speed = 20f;
    float Movementpercentge = 0f;
    float rewindMovementperc = 0f;
    Vector3 targetPosition;
    Vector3 currPosition;
    bool IsRewinding = false;

    public Bullet(Vector3 TargetPosition)
    {
        Debug.Log("New instance of bullet");
        targetPosition = TargetPosition;
        
    }

    public void Update(float deltaTime)
    {
        // Debug.Log(Movementpercentge.ToString());
        if(Movementpercentge < 1 && IsRewinding == false)
        {
            Forward(deltaTime);
        }

        if(Movementpercentge <= 1.03 && IsRewinding == true)
        {
            Rewind(deltaTime);
        }

        if(Movementpercentge <= 0 && IsRewinding == true)
        {
            IsRewinding = false;
        }

        if(Movementpercentge >= 1 && IsRewinding == false)
        {
            IsRewinding = true;
            currPosition = targetPosition;
            targetPosition = Vector3.zero;
        }
    }

    void Forward(float deltaTime)
    {
        float dist = Mathf.Sqrt(Mathf.Pow((currPosition.x - targetPosition.x), 2) + Mathf.Pow((currPosition.y - targetPosition.y), 2)); // Total Distance that needs to be travelled

        float DistanceThisFrame = speed * deltaTime;

        // How much is that in terms of a percentage to our destination
        float percThisFrame = DistanceThisFrame / dist;

        // Add that to overall percentage traveled percentage 
        Movementpercentge += percThisFrame;

    }
    
    void Rewind(float deltaTime)
    {
        // Debug.Log("Is Rewinding");
        float dist = Mathf.Sqrt(Mathf.Pow((currPosition.x - targetPosition.x), 2) + Mathf.Pow((currPosition.y - targetPosition.y), 2)); // Total Distance that needs to be travelled

        float DistanceThisFrame = speed * deltaTime;

        // How much is that in terms of a percentage to our destination
        float percThisFrame = DistanceThisFrame / dist;

        // Add that to overall percentage traveled percentage 
        Movementpercentge -= percThisFrame;

        Debug.Log(Movementpercentge.ToString());
    }

   
    
}



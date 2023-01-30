using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetMover : MonoBehaviour
{
    private static float s_speed = 5;
    private static float s_maxSpeed = 30;
    private static float s_minSpeed = 5;

    public float Speed { get { return s_speed; } }

    private void Update()
    {
        transform.Translate(Vector3.down * s_speed * Time.deltaTime);
    }

    public void AddSpeed(float speed)
    {
        if (speed + s_speed >= s_minSpeed && speed + s_speed <= s_maxSpeed)
            s_speed += speed;
    }
    
    public void ChangeStartSpeed(float speed)
    {
        if (speed + s_speed >= s_minSpeed && speed + s_speed <= s_maxSpeed)
            s_speed = speed;
    }

    public void ChangeMaxSpeed(float speed) => s_maxSpeed = speed;
    
    public void ChangeMinSpeed(float speed) => s_minSpeed = speed;
}

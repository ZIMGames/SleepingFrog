using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Mover : MonoBehaviour
    {
        private float speed;
        private Vector3 dir;

        private void Start()
        {
            speed = GetComponent<Controller>().speed;
            dir = StaticHelper.GetDirection(transform.position);
        }

        private void FixedUpdate()
        {
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}

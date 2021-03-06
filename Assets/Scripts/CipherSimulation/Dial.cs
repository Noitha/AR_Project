﻿using UnityEngine;

namespace CipherSimulation
{
    public class Dial : MonoBehaviour
    {

        private readonly Vector3 rotation = new Vector3(45, 0, 0);

        public void Up()
        {
            transform.Rotate(-rotation);
        }

        public void Down()
        {
            transform.Rotate(rotation);
        }
    }
}
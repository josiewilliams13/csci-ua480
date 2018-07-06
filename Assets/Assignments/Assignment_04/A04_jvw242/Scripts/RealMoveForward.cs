using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace A03_jvw242
{

    public class RealMoveForward : MonoBehaviour
    {

        public float speed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                //Debug.Log("MOUSE BYTTON PRESSED");
                //speed * Time.deltaTime;
                transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
            }
        }
    }
}
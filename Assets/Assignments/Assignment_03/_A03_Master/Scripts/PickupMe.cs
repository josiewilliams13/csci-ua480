using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03Examples
{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class PickupMe : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        //StrobeSelected strobe;
        public DrawDownPointer downPointer;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            //strobe = GetComponent<StrobeSelected>();
        }

        // Update is called once per frame
        void Update()
        {
            if (grabbed && (downPointer != null)) {
                downPointer.DrawLine(transform.position);
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */

        //Prop. of rb called velocity. if collision is detected, set velocity to zero.
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.useGravity = true;  //    .useGravity = true;
                if (downPointer != null)
                    downPointer.DontDraw();
            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                //on collision enter --> collision.
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                myRb.useGravity = false; //  .useGravity = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            transform.parent = null;
        }
    }
}

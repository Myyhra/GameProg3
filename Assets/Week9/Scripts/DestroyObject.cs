using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week9
{


    public class DestroyObject : MonoBehaviour
    {
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Gravitable")
            {
                rb.isKinematic = false;
                StartCoroutine(DestroyObjectCoroutine());
            }
        }

        IEnumerator DestroyObjectCoroutine()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}

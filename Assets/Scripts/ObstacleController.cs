using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// ragdoll tutorial for stationary / ragdoll effect
// https://learn.unity.com/tutorial/creating-ragdolls-2019#60009a37edbc2a4a292a2d0f

public class ObstacleController : MonoBehaviour
{
    private GameObject zombi;

    // for stationary / ragdoll effect on obstacle
    [SerializeField] Collider myCollider;
    Rigidbody[] rigidBodies;
    bool obstacleIsRagdoll = false;

    // Start is called before the first frame update
    void Start()
    {
        zombi = GameObject.Find("Zombi");
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        ActivateRagdoll(false);  // sets obstacle to be stationary
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == zombi.GetComponent<BoxCollider>())
        {
            Debug.Log("Car within range of obstacle.");
        }
    }

    // true to make obstacle ragdoll, false to keep obstacle stationary
    private void ActivateRagdoll(bool makeRagdoll)
    {
        obstacleIsRagdoll = makeRagdoll;

        myCollider.enabled = !makeRagdoll;
        foreach (Rigidbody ragdollBone in rigidBodies)
        {
            ragdollBone.isKinematic = !makeRagdoll;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!obstacleIsRagdoll && collision.gameObject == zombi)
        {
            ActivateRagdoll(true);
        }
    }
}

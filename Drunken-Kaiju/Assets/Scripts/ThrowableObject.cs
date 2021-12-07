using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public float breakForce;
    public float breakLimit;

    public enum ThrowableTypes { boat, boulder, bus, car, iceCream, bottle };
    public ThrowableTypes throwableTypes = ThrowableTypes.car;

    [HideInInspector] public int objHealth;
    [HideInInspector] public bool canBeHeld;

    Rigidbody rb;
    float yVelocity;

    GameObject smokeFX;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        if (transform.GetChild(0).GetComponent<ParticleSystem>())
        {
            smokeFX = transform.GetChild(0).gameObject;
            smokeFX.SetActive(false);
        }
        else
        {
            smokeFX = null;
        }

        switch (throwableTypes)
        {
            case ThrowableTypes.boat:
                gameObject.name = "Boat";
                objHealth = 3;
                break;

            case ThrowableTypes.boulder:
                gameObject.name = "Boulder";
                objHealth = 5;
                break;

            case ThrowableTypes.bus:
                gameObject.name = "Bus";
                objHealth = 2;
                break;

            case ThrowableTypes.car:
                gameObject.name = "Car";
                objHealth = 1;
                break;

            case ThrowableTypes.iceCream:
                gameObject.name = "Ice Cream";
                objHealth = 2;
                break;

            case ThrowableTypes.bottle:
                gameObject.name = "Radiation Bottle";
                objHealth = 1;
                break;
        }

        if(gameObject.transform.parent != null)
        {
            gameObject.transform.parent = null;
        }
    }

    void Update()
    {
        yVelocity = -rb.velocity.y;

        if (objHealth <= 0)
        {
            Destruction();
        }

        if(gameObject != KaijuMovement.singleton.heldObj)
        {
            //gameObject.layer = 0;
        }

        if(objHealth == 1 && smokeFX != null)
        {
            smokeFX.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (yVelocity > breakLimit)
        {
            if(!col.gameObject.GetComponent<ThrowableObject>() || col.gameObject.layer != 4 /*|| col.gameObject.layer != 7 || col.gameObject.layer != 8 || col.gameObject.layer != 10*/)
            {
                if(throwableTypes != ThrowableTypes.boulder)
                {
                    objHealth -= 1;
                }
            } 
            else if (col.gameObject.GetComponent<DestructableObject>())
            {
                //objHealth -= 1;
            }
        }

        if(col.gameObject.layer != 6 && canBeHeld == false)
        {
            canBeHeld = true;
        }

        if (col.gameObject.GetComponent<Rigidbody>() && col.gameObject.tag != "Player")
        {
            if (col.gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude > 5)
            {
                if (col.gameObject.layer != 7)
                {
                    objHealth -= 1;
                }

                if(col.gameObject.layer != 7 && objHealth >= 1)
                {
                    ScoreManager.singleton.standardScore += 50;
                }

            }
        }

    }

    private void OnParticleCollision(GameObject col)
    {
        if (col.gameObject.tag == "Puke")
        {
            Debug.Log("bruh");
            Destruction();
        }
    }

    void Destruction()
    {
        Destroy(gameObject);

        if (objHealth == 1 && smokeFX != null)
        {
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
            gameObject.transform.GetChild(0).GetComponent<AutoCleaner>().enabled = true;
            gameObject.transform.GetChild(0).parent = null;
        }

        switch (throwableTypes)
        {
            case ThrowableTypes.boat:

                GameObject bD = Instantiate(BuildingManager.singleton.destroyedThrowables[0], this.transform.position, this.transform.rotation);
                bD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in bD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case ThrowableTypes.boulder:

                GameObject boldD = Instantiate(BuildingManager.singleton.destroyedThrowables[1], this.transform.position, this.transform.rotation);
                boldD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in boldD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case ThrowableTypes.bus:

                GameObject busD = Instantiate(BuildingManager.singleton.destroyedThrowables[2], this.transform.position, this.transform.rotation);
                busD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in busD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case ThrowableTypes.car:

                GameObject carD = Instantiate(BuildingManager.singleton.destroyedThrowables[3], this.transform.position, this.transform.rotation);
                carD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in carD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }

                KaijuMovement.singleton.health = 100;

                break;

            case ThrowableTypes.iceCream:

                GameObject iceD = Instantiate(BuildingManager.singleton.destroyedThrowables[4], this.transform.position, this.transform.rotation);
                iceD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in iceD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case ThrowableTypes.bottle:

                GameObject bottleD = Instantiate(BuildingManager.singleton.destroyedThrowables[5], this.transform.position, this.transform.rotation);
                bottleD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Renderer mat in bottleD.GetComponentsInChildren<Renderer>())
                {
                    mat.material = gameObject.GetComponent<Renderer>().material;
                }

                foreach (Rigidbody rb in bottleD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;
        }

        if (KaijuMovement.singleton.heldObj == gameObject)
        {
            KaijuMovement.singleton.heldObj = null;
        }
    }
}

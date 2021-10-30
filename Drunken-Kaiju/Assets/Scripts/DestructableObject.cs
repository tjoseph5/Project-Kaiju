using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{

    [Range(0,100)] [HideInInspector] public float health;
    public float breakForce;

    public enum BuildingTypes { billboard, factory, genericStore, hospital, house, nuclearSmokeStack, officeBuilding, skyscraper, smokeStack, warehouse, windTurbine };
    public BuildingTypes buildingTypes = BuildingTypes.house;

    Transform player;

    private void Awake()
    {
        
    }

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (buildingTypes)
        {
            case BuildingTypes.house:
                gameObject.name = "House";

                break;

            case BuildingTypes.skyscraper:
                gameObject.name = "Skyscraper";

                break;

            case BuildingTypes.warehouse:
                gameObject.name = "Warehouse";

                break;

            case BuildingTypes.billboard:
                gameObject.name = "Billboard";

                break;

            case BuildingTypes.factory:
                gameObject.name = "Factory";

                break;

            case BuildingTypes.genericStore:
                gameObject.name = "Generic Store";

                break;

            case BuildingTypes.hospital:
                gameObject.name = "Hosptial";

                break;

            case BuildingTypes.nuclearSmokeStack:
                gameObject.name = "Nuclear Smoke Stack";

                break;

            case BuildingTypes.officeBuilding:
                gameObject.name = "Office Building";

                break;

            case BuildingTypes.smokeStack:
                gameObject.name = "Smoke Stack";

                break;

            case BuildingTypes.windTurbine:
                gameObject.name = "Wind Turbine";

                break;
        }
    }


    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destruction();
        }

        if (col.gameObject.GetComponent<Rigidbody>() && col.gameObject.tag != "Player")
        {
            if(col.gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude > 15)
            {
                if(col.gameObject.layer != 7)
                {
                    Destruction();
                }
            }
        }
    }

    private void OnParticleCollision(GameObject col)
    {
        if(col.gameObject.tag == "Puke")
        {
            Debug.Log("bruh");
            Destruction();
        }
    }

    void Destruction()
    {
        //gameObject.GetComponent<Collider>().enabled = false;
        //Debug.Log(gameObject.GetComponent<Collider>().enabled);
        Destroy(gameObject);

        switch (buildingTypes)
        {
            case BuildingTypes.billboard:

                GameObject bD = Instantiate(BuildingManager.singleton.destroyedBuildings[0], this.transform.position, this.transform.rotation);
                bD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in bD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.factory:

                GameObject fD = Instantiate(BuildingManager.singleton.destroyedBuildings[1], this.transform.position, this.transform.rotation);
                fD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in fD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.genericStore:

                GameObject gSD = Instantiate(BuildingManager.singleton.destroyedBuildings[2], this.transform.position, this.transform.rotation);
                gSD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in gSD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.hospital:

                GameObject hospD = Instantiate(BuildingManager.singleton.destroyedBuildings[3], this.transform.position, this.transform.rotation);
                hospD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in hospD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.house:

                GameObject houseD = Instantiate(BuildingManager.singleton.destroyedBuildings[4], this.transform.position, this.transform.rotation);
                houseD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in houseD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.nuclearSmokeStack:

                GameObject nSSD = Instantiate(BuildingManager.singleton.destroyedBuildings[5], this.transform.position, this.transform.rotation);
                nSSD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in nSSD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.officeBuilding:

                GameObject oBD = Instantiate(BuildingManager.singleton.destroyedBuildings[6], this.transform.position, this.transform.rotation);
                oBD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in oBD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.skyscraper:

                GameObject skyD = Instantiate(BuildingManager.singleton.destroyedBuildings[7], this.transform.position, this.transform.rotation);
                skyD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in skyD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.smokeStack:

                GameObject sSD = Instantiate(BuildingManager.singleton.destroyedBuildings[8], this.transform.position, this.transform.rotation);
                sSD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in sSD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.warehouse:

                GameObject wD = Instantiate(BuildingManager.singleton.destroyedBuildings[9], this.transform.position, this.transform.rotation);
                wD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in wD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;

            case BuildingTypes.windTurbine:

                GameObject wTD = Instantiate(BuildingManager.singleton.destroyedBuildings[10], this.transform.position, this.transform.rotation);
                wTD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in wTD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;
        }

        if (gameObject.GetComponent<Collider>().enabled == false)
        {
            

            
        }
    }   
}
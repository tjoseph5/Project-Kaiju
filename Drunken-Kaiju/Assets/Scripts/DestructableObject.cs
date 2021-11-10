using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{


    public float breakForce;

    public enum BuildingTypes { billboard, factory, genericStore, hospital, house, nuclearSmokeStack, officeBuilding, skyscraper, smokeStack, warehouse, windTurbine, apartment };
    public BuildingTypes buildingTypes = BuildingTypes.house;

    GameObject player;

    public bool buildingHealth;
    [Range(0, 100)] public int health;
    [HideInInspector] public bool recentlyHit;

    void Start()
    {
        if (buildingHealth)
        {
            health = 100;
        }
        else
        {
            health = 0;
        }


        //player = GameObject.FindGameObjectWithTag("Player").transform;
        player = null;

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

            case BuildingTypes.apartment:
                gameObject.name = "Apartment";

                break;
        }
    }

    void Update()
    {
        if (buildingHealth && health <= 0)
        {
            if(player == null && !recentlyHit)
            {
                ScoreAddition(true, buildingHealth);
            }
            else if(player != null || recentlyHit)
            {
                ScoreAddition(false, buildingHealth);
            }
            Destruction();
        }
    }


    void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = col.gameObject;
                Debug.Log("Player collision is now: " + player.name);
            }
        }

        if(col.gameObject == player)
        {
            if(!buildingHealth)
            {
                ScoreAddition(cRHit: false, buildingHealth);
                Destruction();
            }

            if(buildingHealth && health > 0 && KaijuMovement.singleton.activateRagdoll)
            {
                health -= 5;
            }
        }

        if (col.gameObject.GetComponent<Rigidbody>() && col.gameObject.tag != "Player")
        {
            if(col.gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude > 5)
            {
                if(col.gameObject.layer != 7)
                {
                    if(buildingHealth && health > 0)
                    {
                        recentlyHit = false;
                        if(col.gameObject.GetComponent<Rigidbody>().mass <= 1)
                        {
                            health -= 50;
                        }
                        else if(col.gameObject.GetComponent<Rigidbody>().mass > 1)
                        {
                            health = 0;
                        }
                        
                    }

                    if (!buildingHealth || buildingHealth && health <= 0)
                    {
                        ScoreAddition(true, buildingHealth);
                        Destruction();
                    }

                    if (col.gameObject.GetComponent<ThrowableObject>())
                    {
                        col.gameObject.GetComponent<ThrowableObject>().objHealth -= 1;
                    }
                }
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject == player)
        {
            if(player != null)
            {
                player = null;
            }
        }
    }

    private void OnParticleCollision(GameObject col)
    {
        if(col.gameObject.tag == "Puke")
        {
            Debug.Log("bruh");
            ScoreAddition(true, buildingHealth);
            Destruction();
        }
    }

    void Destruction()
    {
        Destroy(gameObject);

        switch (buildingTypes)
        {
            case BuildingTypes.billboard:

                GameObject bD = Instantiate(BuildingManager.singleton.destroyedBuildings[0], this.transform.position, this.transform.rotation);
                bD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Renderer mat in bD.GetComponentsInChildren<Renderer>())
                {
                    mat.material = gameObject.GetComponent<Renderer>().material;
                }

                foreach (Rigidbody rb in bD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }

                //ScoreManager.singleton.standardScore += 400;

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

                KaijuMovement.singleton.health = 100;

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
                KaijuMovement.singleton.pukeAmount = 100;

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

                ScoreManager.singleton.standardScore += 900;

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

            case BuildingTypes.apartment:

                GameObject aD = Instantiate(BuildingManager.singleton.destroyedBuildings[11], this.transform.position, this.transform.rotation);
                aD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

                foreach (Rigidbody rb in aD.GetComponentsInChildren<Rigidbody>())
                {
                    Vector3 force = (rb.transform.position - transform.position).normalized * breakForce;
                    rb.AddForce(force);
                }
                break;
        }
    }

    void ScoreAddition(bool cRHit = false, bool isSpecial = false)
    {
        if (cRHit)
        {
            ScoreManager.singleton.tempCRScoreTimer = 5;

            if(ScoreManager.singleton.tempCRScoreTimer > 0)
            {
                ScoreManager.singleton.tempCRMultiplier += 1;
            }

            if (ScoreManager.singleton.tempCRScoreTimer >= 1)
            {
                ScoreManager.singleton.chainReactionMultiplier += 1;
            }

            if (ScoreManager.singleton.tempCRMultiplier > 0)
            {
                ScoreManager.singleton.standardScore += ScoreManager.singleton.defaultGivenScore * ScoreManager.singleton.tempCRMultiplier;
            }
        }
        else
        {
            ScoreManager.singleton.standardScore += ScoreManager.singleton.defaultGivenScore;
        }

        if (isSpecial)
        {
            ScoreManager.singleton.specialBuildingMultiplier += 1;
        }
    }

    private void OnDestroy()
    {
        if(buildingTypes == BuildingTypes.warehouse)
        {
            /*
            gameObject.transform.GetChild(0).GetComponent<MeshCollider>().enabled = true;
            gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            */
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //gameObject.transform.GetChild(0).parent = null;
        }
    }
}
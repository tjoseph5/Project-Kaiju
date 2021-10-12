using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{

    public float health;
    [SerializeField] GameObject[] destroyedBuildings;

    public enum BuildingTypes { house, skyscraper, warehouse, extra};
    public BuildingTypes buildingTypes = BuildingTypes.house;


    private void Awake()
    {
        
    }

    void Start()
    {
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

            case BuildingTypes.extra:
                gameObject.name = "Extra";

                break;
        }
    }


    void Update()
    {
        /*
        foreach (GameObject obj in destroyedBuildings)
        {
            obj.transform.localScale = gameObject.transform.localScale;
        }
        */
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            switch (buildingTypes)
            {
                case BuildingTypes.house:

                    GameObject houseD = Instantiate(destroyedBuildings[0], this.transform.position, this.transform.rotation);
                    houseD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                    break;

                case BuildingTypes.skyscraper:

                    GameObject skyD = Instantiate(destroyedBuildings[1], this.transform.position, this.transform.rotation);
                    skyD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                    break;

                case BuildingTypes.warehouse:

                    GameObject warehouseD = Instantiate(destroyedBuildings[2], this.transform.position, this.transform.rotation);
                    warehouseD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                    break;

                case BuildingTypes.extra:

                    GameObject extraD = Instantiate(destroyedBuildings[3], this.transform.position, this.transform.rotation);
                    extraD.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                    break;
            }
        }
    }
}

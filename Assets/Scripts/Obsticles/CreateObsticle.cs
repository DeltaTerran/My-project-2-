using System.Collections.Generic;
using UnityEngine;

public class CreateObsticle : MonoBehaviour
{
    public GameObject obsticleObj_Big;
    public GameObject obsticleObj_Upper;
    public GameObject obsticleObj;
    private int _randNum;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region Spawn

        _randNum = Random.Range(0, 11);
        switch (_randNum)
        {
            case 0:
                Instantiate(obsticleObj_Big, new Vector3(1, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                Instantiate(obsticleObj, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                break;
            case 1:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj, new Vector3(0, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(-1, 2.5f, transform.position.z), obsticleObj_Upper.transform.rotation);

                break;
            case 2:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj, new Vector3(0, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Big, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                break;
            case 3:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.transform.rotation);
                Instantiate(obsticleObj, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                break;
            case 4:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                Instantiate(obsticleObj, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                break;
            case 5:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.transform.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(-1, 2.5f, transform.position.z), obsticleObj_Upper.transform.rotation);
                break;
            case 6:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.transform.rotation);
                Instantiate(obsticleObj_Big, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                break;
            case 7:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                Instantiate(obsticleObj_Big, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation); break;
            case 8:
                Instantiate(obsticleObj_Upper, new Vector3(1, 2.5f, transform.position.z), obsticleObj_Upper.transform.rotation);
                Instantiate(obsticleObj, new Vector3(0, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                break;
            case 9:
                Instantiate(obsticleObj_Big, new Vector3(1, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                Instantiate(obsticleObj, new Vector3(0, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj.transform.rotation); break;
            case 10:
                Instantiate(obsticleObj, new Vector3(1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.transform.rotation);
                Instantiate(obsticleObj, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj.transform.rotation); break;
            case 11:
                Instantiate(obsticleObj_Big, new Vector3(1, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big.transform.rotation);
                Instantiate(obsticleObj, new Vector3(-1, transform.position.y, transform.position.z), obsticleObj.transform.rotation);
                break;
        }

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}

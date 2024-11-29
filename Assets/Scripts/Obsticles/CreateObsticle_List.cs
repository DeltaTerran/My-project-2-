using System.Collections.Generic;
using UnityEngine;

public class CreateObsticle_List : MonoBehaviour
{
    public List<GameObject> obsticleObj_Big;
    public List<GameObject> obsticleObj_Upper;
    public List<GameObject> obsticleObj;
    private int _randNum;
    private int _randOOB;
    private int _randOOU;
    private int _randOO;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region Spawn

        _randNum = Random.Range(0, 11);
        _randOO = Random.Range(0, obsticleObj.Count);
        _randOOU = Random.Range(0, obsticleObj_Upper.Count);
        _randOOB = Random.Range(0, obsticleObj_Big.Count);
        switch (_randNum)
        {
            case 0:
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(1, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                break;
            case 1:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(0, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Upper[_randOOU], new Vector3(-1, 2.5f, transform.position.z), obsticleObj_Upper[_randOOU].transform.rotation);

                break;
            case 2:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(0, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                break;
            case 3:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Upper[_randOOU], new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper[_randOOU].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                break;
            case 4:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                break;
            case 5:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Upper[_randOOU], new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper[_randOOU].transform.rotation);
                Instantiate(obsticleObj_Upper[_randOOU], new Vector3(-1, 2.5f, transform.position.z), obsticleObj_Upper[_randOOU].transform.rotation);
                break;
            case 6:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Upper[_randOOU], new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper[_randOOU].transform.rotation);
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                break;
            case 7:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation); break;
            case 8:
                Instantiate(obsticleObj_Upper[_randOOU], new Vector3(1, 2.5f, transform.position.z), obsticleObj_Upper[_randOOU].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(0, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                break;
            case 9:
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(1, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(0, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation); break;
            case 10:
                Instantiate(obsticleObj[_randOO], new Vector3(1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                Instantiate(obsticleObj_Upper[_randOOU], new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper[_randOOU].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation); break;
            case 11:
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(1, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                Instantiate(obsticleObj_Big[_randOOB], new Vector3(0, transform.position.y, transform.position.z), obsticleObj_Big[_randOOB].transform.rotation);
                Instantiate(obsticleObj[_randOO], new Vector3(-1, transform.position.y, transform.position.z), obsticleObj[_randOO].transform.rotation);
                break;
        }

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}

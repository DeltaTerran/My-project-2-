using UnityEngine;

public class CreateObsticle : MonoBehaviour
{
    public Transform obsticleObj_Big;
    public Transform obsticleObj_Upper;
    public Transform obsticleObj;
    private int _randNum;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _randNum = Random.Range(0, 11);
        switch (_randNum)
        {
            case 0:
                Instantiate(obsticleObj_Big, new Vector3(1, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                Instantiate(obsticleObj, new Vector3(-1, 1.1f, transform.position.z), obsticleObj.rotation);
                break;
            case 1:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj, new Vector3(0, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(-1, 2.5f, transform.position.z), obsticleObj_Upper.rotation);

                break;
            case 2:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj, new Vector3(0, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Big, new Vector3(-1, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                break;
            case 3:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.rotation);
                Instantiate(obsticleObj, new Vector3(-1, 1.1f, transform.position.z), obsticleObj.rotation);
                break;
            case 4:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                Instantiate(obsticleObj, new Vector3(-1, 1.1f, transform.position.z), obsticleObj.rotation);
                break;
            case 5:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(-1, 2.5f, transform.position.z), obsticleObj_Upper.rotation);
                break;
            case 6:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.rotation);
                Instantiate(obsticleObj_Big, new Vector3(-1, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                break;
            case 7:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                Instantiate(obsticleObj_Big, new Vector3(-1, 1.1f, transform.position.z), obsticleObj_Big.rotation); break;
            case 8:
                Instantiate(obsticleObj_Upper, new Vector3(1, 2.5f, transform.position.z), obsticleObj_Upper.rotation);
                Instantiate(obsticleObj, new Vector3(0, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj, new Vector3(-1, 1.1f, transform.position.z), obsticleObj.rotation);
                break;
            case 9:
                Instantiate(obsticleObj_Big, new Vector3(1, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                Instantiate(obsticleObj, new Vector3(0, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj, new Vector3(-1, 1.1f, transform.position.z), obsticleObj.rotation); break;
            case 10:
                Instantiate(obsticleObj, new Vector3(1, 1.1f, transform.position.z), obsticleObj.rotation);
                Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, transform.position.z), obsticleObj_Upper.rotation);
                Instantiate(obsticleObj, new Vector3(-1, 1.1f, transform.position.z), obsticleObj.rotation); break;
            case 11:
                Instantiate(obsticleObj_Big, new Vector3(1, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, transform.position.z), obsticleObj_Big.rotation);
                Instantiate(obsticleObj, new Vector3(-1, 1.1f, transform.position.z), obsticleObj.rotation);
                break;
        }
        }

        // Update is called once per frame
        void Update()
    {
        
    }


}

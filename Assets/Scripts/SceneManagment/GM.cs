using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static float VertVel = 0;
    public static float HorizVel = 0;
    public static int CoinTotal = 0;
    public static float TimeTotal = 0;
    public float waittoload = 0;

    public static float ZVelAdj = 1;
    //public float ZScenePos_Plat = 0;
    //public float ZScenePos_OBST = 30;

    public static string LvlCompStatus = "";

    public Transform bbNoPit; 
    public Transform bbPitMid;

    public Transform coinObj;
    public Transform obsticleObj;
    public Transform obsticleObj_Big;
    public Transform obsticleObj_Upper;
    public Transform PowerUp;

    public int RandNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


        #region Текущий спавн
        #region Platform Spawn
        //if (ZScenePos_Plat < 1000)
        //{
        //    Instantiate(bbNoPit, new Vector3(0, 0, ZScenePos_Plat), bbNoPit.rotation);
        //    ZScenePos_Plat += 4;
        //}
        #endregion
        /*
        if (ZScenePos_OBST < 1000)
        {
            #region without coins
            randNum = Random.Range(0, 11);
                    //switch (randNum)
                    //{
                    //    case 0:
                    //        Instantiate(obsticleObj_Big, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        Instantiate(obsticleObj, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        break;
                    //    case 1:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Upper, new Vector3(-1, 2.5f, ZScenePos_OBST), obsticleObj_Upper.rotation);

                    //        break;
                    //    case 2:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Big, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        break;
                    //    case 3:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, ZScenePos_OBST), obsticleObj_Upper.rotation);
                    //        Instantiate(obsticleObj, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        break;
                    //    case 4:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        Instantiate(obsticleObj, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        break;
                    //    case 5:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, ZScenePos_OBST), obsticleObj_Upper.rotation);
                    //        Instantiate(obsticleObj_Upper, new Vector3(-1, 2.5f, ZScenePos_OBST), obsticleObj_Upper.rotation);
                    //        break;
                    //    case 6:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, ZScenePos_OBST), obsticleObj_Upper.rotation);
                    //        Instantiate(obsticleObj_Big, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        break;
                    //    case 7:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        Instantiate(obsticleObj_Big, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation); break;
                    //    case 8:
                    //        Instantiate(obsticleObj_Upper, new Vector3(1, 2.5f, ZScenePos_OBST), obsticleObj_Upper.rotation);
                    //        Instantiate(obsticleObj, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        break;
                    //    case 9:
                    //        Instantiate(obsticleObj_Big, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        Instantiate(obsticleObj, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj.rotation); break;
                    //    case 10:
                    //        Instantiate(obsticleObj, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj.rotation);
                    //        Instantiate(obsticleObj_Upper, new Vector3(0, 2.5f, ZScenePos_OBST), obsticleObj_Upper.rotation);
                    //        Instantiate(obsticleObj, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj.rotation); break;
                    //    case 11:
                    //        Instantiate(obsticleObj_Big, new Vector3(1, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        Instantiate(obsticleObj_Big, new Vector3(0, 1.1f, ZScenePos_OBST), obsticleObj_Big.rotation);
                    //        Instantiate(obsticleObj, new Vector3(-1, 1.1f, ZScenePos_OBST), obsticleObj.rotation); 
                    //        break;

                    //}
            #endregion
            
            ZScenePos_OBST += 20;
        }
        */
        #endregion
        
        TimeTotal += Time.deltaTime;

        if (LvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;
        }
        if (waittoload > 2)
        {
            SceneManager.LoadScene("Outro");
        }
    }
    public static void ResetGMValues()
    {
        VertVel = 0;
        HorizVel = 0;
        CoinTotal = 0;
        TimeTotal = 0;
        ZVelAdj = 0;
        LvlCompStatus = "";
    }
}

using UnityEngine;
using System.Collections;

public static class QbertFunction
{

    public static void SavePosition(string key, Transform t)
    {
        string[] k = { key, key, key };
        PlayerPrefs.SetFloat(k[0], t.position.x);
        PlayerPrefs.SetFloat(k[1], t.position.y +1);
        PlayerPrefs.SetFloat(k[2], t.position.z);
    }
   public static Vector3 LastPosition(string key, Transform transform)
    {
        string[] k = { key, key, key };
        return transform.position = new Vector3(PlayerPrefs.GetFloat(k[0]), PlayerPrefs.GetFloat(k[1]), PlayerPrefs.GetFloat(k[2]));
    }

   //public static void Respawn() 
   //{
   
   //}
}

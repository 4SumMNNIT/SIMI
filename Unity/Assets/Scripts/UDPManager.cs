using Unity.VisualScripting;
using UnityEngine;
public class UDPManager : MonoBehaviour
{
    public static UDPManager Instance;
    private static string data;

    public static string GetData(){
        return data;
    }

    public static string[] GetDataPoints(){
        string temp = data.Remove(0, 1);
        temp = temp.Remove(data.Length - 1, 1);
        return temp.Split(',');
    }

    internal static void SetData(string data){
        UDPManager.data = data;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

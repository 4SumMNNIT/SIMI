using Unity.VisualScripting;
using UnityEngine;
public class UDPManager : MonoBehaviour
{
    public static UDPManager Instance;
    private string data;

    public string GetData(){
        return data;
    }

    public string[] GetDataPoints(){
        string temp = data.Remove(0, 1);
        temp = temp.Remove(temp.Length - 1, 1);
        return temp.Split(',');
    }

    internal void SetData(string data){
        Instance.data = data;
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

    void Update(){
        // Debug.Log(data);
    }
}

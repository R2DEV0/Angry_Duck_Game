using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundScript : MonoBehaviour
{
    public static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }        
    }
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}

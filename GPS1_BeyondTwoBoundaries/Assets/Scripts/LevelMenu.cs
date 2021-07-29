using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update    

    public void LoadLevel(int sceenLoad)
    {
        SceneManager.LoadScene(sceenLoad);
    }
}

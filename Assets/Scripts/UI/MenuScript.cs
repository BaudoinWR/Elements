using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public void FuseScene()
    {
        SceneManager.LoadScene("Fuse");
    }

    public void HarvestScene()
    {
        SceneManager.LoadScene("Harvest");
    }

}

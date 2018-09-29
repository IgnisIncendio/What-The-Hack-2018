using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuResetScene : MenuInteractable
{
    public override void Press()
    {
        base.Press();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

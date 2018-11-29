using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButton : MonoBehaviour
{
    private GameController gameController;

    public void perfectDrawing()
    {
        gameController.perfectDrawing();
    }
    public void fireMixtape()
    {
        gameController.fireMixTape();
    }
    public void rickRoll()
    {
        gameController.rickRoll();
    }
    public void efficientCode()
    {
        gameController.efficientCode();
    }
    public void amazingPresentation()
    {
        gameController.amazingPresentation();
    }
    public void suitOn()
    {
        gameController.suitOn();
    }
    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }
}

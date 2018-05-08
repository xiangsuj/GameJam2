using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager  {

    protected GameFacade mGameFacade;

    public BaseManager(GameFacade gameFacade)
    {
        this.mGameFacade = gameFacade;
    }
    public virtual void OnInit() { }
    public virtual void Update() { }
    public virtual void OnDestroy() { }
}

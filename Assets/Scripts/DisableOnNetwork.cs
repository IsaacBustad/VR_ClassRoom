using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class DisableOnNetwork : NetworkBehaviour
{
    #region Vars
    [SerializeField] protected List<GameObject> toDisableLst = new List<GameObject>();
    [SerializeField] protected MonoBehaviour[] localOnlyComponents;
    #endregion Vars

    #region Methods
    public override void OnStartClient()
    {
        base.OnStartClient();

        NetDisable();
    }

    protected virtual void NetDisable()
    {
        if(!isOwned)
        {
            gameObject.SetActive(false);

            foreach(GameObject go in toDisableLst)
            {
                go.SetActive(false);
            }

            foreach(MonoBehaviour comp in localOnlyComponents)
            {
                comp.enabled = false;
            }
        }
        
    }

    #endregion Methods
    
}

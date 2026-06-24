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

        NetEnable();
    }

    protected virtual void NetEnable()
    {
        if(isOwned)
        {
            gameObject.SetActive(true);

            foreach(GameObject go in toDisableLst)
            {
                go.SetActive(true);
            }

            foreach(MonoBehaviour comp in localOnlyComponents)
            {
                comp.enabled = true;
            }
        }
        
    }

    #endregion Methods
    
}

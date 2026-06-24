// Created By   :   Isaac Bustad
// Created      :   6/22/2026


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.XR.Interaction.Toolkit;


namespace BugFreeProductions.Tools
{    
    public class NetXrInteractable : NetworkBehaviour
    {
        #region Vars
        protected XRGrabInteractable grabInteractable = null;
        #endregion Vars


        #region Methods
        // This fires automatically the exact frame Mirror registers that 
        // this client successfully obtained network ownership.
        public override void OnStartAuthority()
        {
            base.OnStartAuthority();
            Debug.Log($"[NetXrInteractable] Authority secured for NetID: {netId}. Activating XRI tracking.");

            // Turn XRI tracking back on so the object smoothly follows your hand
            if (grabInteractable != null)
            {
                grabInteractable.trackPosition = true;
                grabInteractable.trackRotation = true;
            }
        }

        // This fires automatically when ownership is stripped or dropped.
        public override void OnStopAuthority()
        {
            base.OnStopAuthority();
            Debug.Log($"[NetXrInteractable] Authority lost for NetID: {netId}. Deactivating XRI tracking.");

            // Turn off tracking so remote physics/transforms don't fight local interactions
            if (grabInteractable != null)
            {
                grabInteractable.trackPosition = false;
                grabInteractable.trackRotation = false;
            }
        }
        public override void OnStartClient()
        {
            base.OnStartClient();
            Debug.Log($"[Mirror] Client started for chair: {netId}");
        }
        protected virtual void OnEnable()
        {
            Setup();
        }

        #region Setup
        protected virtual void Setup()
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
        }

        public virtual void OnGrab()
        {
            RequestAuthority();
        }

        public virtual void OnRelease()
        {
            RemoveAuthority();
        }

        #endregion


        #region Authority
        protected virtual void RequestAuthority()
        {
            //If we are the server/host, we don't send commands. We just take it.
            if (isServer)
            {
                if (netIdentity.connectionToClient != null)
                {
                    netIdentity.RemoveClientAuthority();
                }
            }

            // 2. Pure clients use the command pipeline, but only if they don't already own it
            else if (isClient && !isOwned)
            {
                CmdRequestAuthority();
            }
        }

        protected virtual void RemoveAuthority()
        {
            if (isServer) return;

            if (isClient)
            {
                CmdRemoveAuthority();
            }
            // // If we are the Host/Server, we don't route through commands to drop things.
            // if (isServer) return;

            // // Only ask to remove authority if our local client instance actually owns it right now
            // if (isClient && isOwned)
            // {
            //     CMDRemoveAuthority();
            // }
        }
        
        [Command(requiresAuthority = false)]        
        protected virtual void CmdRequestAuthority()
        {
            // Get explicit references to make the code highly readable
            NetworkConnectionToClient currentOwner = netIdentity.connectionToClient;
            NetworkConnectionToClient requester = connectionToClient;

            // Case A: The object is currently unowned (sitting on the floor)
            if (currentOwner == null)
            {
                netIdentity.AssignClientAuthority(requester);
                Debug.Log($"[NetXrInteractable] Assigned unowned object {gameObject.name} to connection: {requester}");
                
            }

            // Case B: Someone else already owns it (Hand-to-hand pass / Stealing)
            else if (currentOwner != requester)
            {
                netIdentity.RemoveClientAuthority();
                netIdentity.AssignClientAuthority(requester);
                Debug.Log($"[NetXrInteractable] Stole authority of {gameObject.name} from connection {currentOwner} and gave to: {requester}");
                
            }
            
            // 4. Case C: The requester already owns it (Double-grab safety check)
            // No action needed, just exit cleanly
            Debug.Log($"[NetXrInteractable] Server received command from connection: {connectionToClient}");
            
            
        }

        [Command]
        protected virtual void CmdRemoveAuthority()
        {
            NetworkConnectionToClient currentOwner = netIdentity.connectionToClient;
            NetworkConnectionToClient requester = connectionToClient;

            // 1. If it's already server-owned on the floor, do nothing.
            if (currentOwner == null) return;

            // 2. The Server-Side Truth Check:
            // If the person asking to drop it is NOT the person the server recognizes as the true owner,
            // ignore the request completely. Client A's mid-air steal remains safe!
            if (currentOwner != requester)
            {
                Debug.LogWarning($"[NetXrInteractable] Rejected delayed drop command from client {requester}. " +
                                $"Object {gameObject.name} is now owned by {currentOwner}.");
                return;
            }

            // 3. Otherwise, they are verified as the current owner. Cleanly release it.
            netIdentity.RemoveClientAuthority();
            Debug.Log($"[NetXrInteractable] Reclaimed authority over {gameObject.name} from client {requester}.");
        }

        #endregion Authority 

        #endregion Methods
    }
    
}
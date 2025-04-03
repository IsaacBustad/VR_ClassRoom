// Isaac Bustad
// 4/3/2025


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BugFreeProductions.Tools
{
    public class JSONPlacementMannager : MonoBehaviour
    {
        // Vars
        // Singaton instance
        private static JSONPlacementMannager instance = null;

        // factory Refferences
        [SerializeField] private AbstractFactory_SCO abf_SCO = null;

        // pathing varriables
        [SerializeField] private string roomConfigPath = "Default";
        private string objectPlacementPath = "ObjectPlacements.json";
        private string roomPlacementPath = "RoomPointPlacements.json";


        // Mannaged readers and writers
        private MannagedJSONReader jsonReader = new MannagedJSONReader();
        private MannagedJSONWriter jsonWriter = new MannagedJSONWriter();

        // Room object ID and Pool
        [SerializeField] private string roomID = "Room";
        [SerializeField] private GenericPool pool = new GenericPool();



        // Methods
        private void OnEnable()
        {
            if (instance != null)
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                instance = this;
                ReadRoomConfif();
            }
        }

        #region Room Saving
        public void ReadRoomConfif()
        {
            jsonReader.SpawnObjects("/" + roomConfigPath + objectPlacementPath);
        }

        public void WriteRoomConfig()
        {            
            jsonWriter.WriteObjPlacementData("/" +roomConfigPath + roomPlacementPath, roomConfigPath + objectPlacementPath);
        }


        #endregion






        // Accessors
        // Singalton Accesseors
        public static JSONPlacementMannager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("JSONPlacementMannager").AddComponent<JSONPlacementMannager>();
                }
                return instance;
            }
        }

        // Accessors for managed read write
        public AbstractFactory_SCO ABF_SCO { get { return abf_SCO; } }

        public string RoomID { get { return roomID; } }

        public GenericPool Pool { get { return pool; } set { pool = value; } }

    }
}
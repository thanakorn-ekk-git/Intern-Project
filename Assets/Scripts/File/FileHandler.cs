using UnityEngine;

namespace FileManagement
{
    public class FileHandler : MonoBehaviour
    {
        public void Save()
        {
            // TODO : if have no directory path to save => create directory path
            // TODO : if have saved data => delete old one and save game data to persistent data path
            // TODO : if have no saved data => save game data to persistent data path
            // TODO : implement error handling
        }
        public void Load()
        {
            // TODO : pull saved data from persistent data path
            // TODO : implement error handling
        }
    }
}

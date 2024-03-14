using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace Managers
{
    public class SaveManager : MonoBehaviour
    {
        public Action <int,int,int,int> UpdateChestAwards;
    
        private string _dataPath;
    
        private void Awake() 
        { 
            _dataPath = Application.persistentDataPath + "/MySaveData.dat";
        }

        public void SaveChestAwardsData(int goldAward, int diamondAward, int surpriseAward, int healthAward)
        {
            var binaryFormatter = new BinaryFormatter();
            var file = File.Create(_dataPath);

            var data = new SaveData
            {
                ChestGoldAward = goldAward,
                ChestDiamondAward = diamondAward,
                ChestHealthAward = healthAward,
                ChestSurpriseAward = surpriseAward
            };

            binaryFormatter.Serialize(file,data);
            file.Close();
        }

        public void LoadLuckyChestAward()
        {
            if (File.Exists(_dataPath))
            {
                var binaryFormatter = new BinaryFormatter();
                var file = File.Open(_dataPath, FileMode.Open);

                var data = (SaveData)binaryFormatter.Deserialize(file);
            
                var chestGoldAward = data.ChestGoldAward;
                var chestDiamondAward = data.ChestDiamondAward;
                var chestSurpriseAward = data.ChestSurpriseAward;
                var chestHealthAward = data.ChestHealthAward;
            
                file.Close();
            
                UpdateChestAwards?.Invoke(chestGoldAward, chestDiamondAward, chestSurpriseAward, chestHealthAward);
            }
        }
    }

    [Serializable]
    public class SaveData
    {
        public int ChestGoldAward;
        public int ChestDiamondAward;
        public int ChestSurpriseAward;
        public int ChestHealthAward;
    }
}
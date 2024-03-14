using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public static class PrefsManager
    {
        public static void SaveBoughtHero(List<string> boughtHeroes)
        {
            var boughtHeroesString = string.Join(",", boughtHeroes.ToArray());
        
            PlayerPrefs.SetString(GlobalConstants.BOUGHT_HEROES, boughtHeroesString);
            PlayerPrefs.Save();
        }

        public static string LoadBoughtHeroes()
        {
            return PlayerPrefs.GetString(GlobalConstants.BOUGHT_HEROES,"");
        }
    
        public static void SaveActiveHero(string activeHero)
        {
            PlayerPrefs.SetString(GlobalConstants.ACTIVE_HERO,activeHero);
            PlayerPrefs.Save();
        }

        public static string LoadActiveHero()
        {
            return PlayerPrefs.HasKey(GlobalConstants.ACTIVE_HERO) ? PlayerPrefs.GetString(GlobalConstants.ACTIVE_HERO) : null;
        }
    
        public static void SaveGold(int gold)
        {
            PlayerPrefs.SetInt(GlobalConstants.GOLD,gold);
            PlayerPrefs.Save();
        }

        public static int LoadGold()
        {
            return PlayerPrefs.HasKey(GlobalConstants.GOLD) ? PlayerPrefs.GetInt(GlobalConstants.GOLD) : 0;
        }
    
        public static void SaveDiamond(int diamond)
        {
            PlayerPrefs.SetInt(GlobalConstants.DIAMOND,diamond);
            PlayerPrefs.Save();
        }

        public static int LoadDiamond()
        {
            return PlayerPrefs.HasKey(GlobalConstants.DIAMOND) ? PlayerPrefs.GetInt(GlobalConstants.DIAMOND) : 0;
        }

        public static void SaveStartCurrency(int gold,int diamond,int spin)
        {
            if (!PlayerPrefs.HasKey(GlobalConstants.GOLD))
            {
                SaveGold(gold);
            }

            if (!PlayerPrefs.HasKey(GlobalConstants.DIAMOND))
            {
                SaveDiamond(diamond);
            }
        
            if (!PlayerPrefs.HasKey(GlobalConstants.SPIN))
            {
                SaveSpin(spin);
            }
        }

        public static void SaveStartSpins(int spins)
        {
            if (!PlayerPrefs.HasKey(GlobalConstants.SPIN))
            {
                SaveSpin(spins);
            }
        }

        public static void SaveSpin(int spin)
        {
            PlayerPrefs.SetInt(GlobalConstants.SPIN,spin);
            PlayerPrefs.Save();
        }
    
        public static int LoadSpin()
        {
            return PlayerPrefs.HasKey(GlobalConstants.SPIN) ? PlayerPrefs.GetInt(GlobalConstants.SPIN) : 0;
        }
    }
}
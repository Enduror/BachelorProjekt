using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataToSaveScript : MonoBehaviour
{
    public static DataToSaveScript Instance { get; set; }
    
    public static bool isRealTest;
    public static bool isGroupB;

    //PlayerTypeValues
    public static int Socializer_SaveValue;// /
    public static int Achiever_SaveValue;// /
    public static int Conqueror_SaveValue;// /
    public static int Mastermind_SaveValue;// /
    public static int Survivor_SaveValue;// /
    public static int Daredevil_SaveValue;// /
    public static int Seeker_SaveValue;// /
    public static string PrimaryType_SaveValue;// /
    public static string SecondaryType_SaveValue;// /

    //IngameDaten
    public static int DamageDealt_SaveValue;// /
    public static int DamageReceived_SaveValue;// /
    
   
    public static int PlayerDeathCounter_SaveValue;// /
    public static float TotalPlayTime_SaveValue;// /
    public static float NumberOfRestarts_SaveValue;// /
    public static int CollectedPickUps_SaveValue;// /
    public static int FinalBossSpikeCounter_SaveValue;// /
    public static int FinalBossHitCounter_SaveValue;// /

    public static float IdleTime_SaveValue;// /
    public static bool PerfectRun_SaveValue;// /
    public static List<string> LevelPlayerDied_SaveValue = new List<string>();// /
    public static float TimeToFinishGame_SaveValue;// /
    public static bool FinishedTheGame_SaveValue;// /
    public static bool BrokeTheGame_SaveValue;// /
    public static float MaxSpeed_SaveValue;// /

    public static string allPlacesPlayerDied;

    public static bool PlayerKeepedPlaying_SaveValue;

    //AchieveMentRelated;
    public static int DamageReceived_Spikes_SaveValue;// /

    public static int GatheredHealth_SaveValue;// /
    public static int WallHits_SaveValue;// /
    public static int AchievementsFoundCounter_SaveValue;// /
    public static int VasesDestroyed_SaveValue;// /
    public static int EnemiesKilled_SaveValue;// /
    public static bool FoundSecretlevel_SaveValue; // /
    public static bool BossKilledWithTraps_SaveValue=true; //
    public static int PuzzlesSolvedCounter_SaveValue; // /
    public static bool AllPuzzlesSolved_SaveValue; // /
    public static bool SetTheForkOnFire_SaveValue; // /
    public static int SecretsFoundCounter_SaveValue; // /
    public static bool BladeRun_SaveValue;// /
    public static int SteppedOnTrapsCounter_SaveValue;// /
    public static bool SteppedOn5Traps_SaveValue;// /
    
    public static int  AchievementsDoneCounter_SaveValue;// /
    public static bool AllAchievementsDone_SaveValue;// /

    public static bool firstTry;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        firstTry = true;
    }

    public void Update()
    {
      
        TotalPlayTime_SaveValue += Time.deltaTime;
        if (DamageReceived_SaveValue != 0)
        {
            PerfectRun_SaveValue = false;
        }              
        if (AchievementsDoneCounter_SaveValue >= 3)
        {
            AllAchievementsDone_SaveValue = true;
        }
        if (FinalBossSpikeCounter_SaveValue >= 12)
        {
            BossKilledWithTraps_SaveValue = true;
        }
        if (FinishedTheGame_SaveValue == true && PlayerDeathCounter_SaveValue == 0)
        {
            PerfectRun_SaveValue = true;
        }        
        
    }
   
    public static void SaveAllData()
    {
        string path = Application.dataPath + "/DataToSave.csv";
        
        if (!File.Exists(path))
        {
            
            File.WriteAllText(path, "PlayerID;Socializer;Achiever;Conqueror;Mastermind;Survivor;Daredevil;Seeker;PrimaryType;SecondaryType;DamageDealt;DamageReceived;PlayerDeathCounter;TotalPlayTime;" +
                "NumberOfRestarts;CollectedPickUps;FinalBossSpikeCounter;FinalBossHitCounter;IdleTime;PerfectRun;TimeToFinishGame;BrokeTheGame;MaxSpeed;DamageReceived_Spikes;" +
                "GatheredHealth;WallHits;VasesDestroyed;EnemiesKilled;FoundSecretlevel;BossKilledWithTraps;PuzzlesSolvedCounter;AllPuzzlesSolved;SetTheForkOnFire;" +
                "SecretsFoundCounter;BladeRun;SteppedOn5TrapsCounter;AchievementsDoneCounter;AllAchievementsDone;AllLevelsPlayerDied;"+"\n");

        }


        // save all deathplaces
        
        
        foreach( string s in LevelPlayerDied_SaveValue)
        {
            allPlacesPlayerDied += s+"\n";
        }



        File.AppendAllText(path, PlayerPrefs.GetInt("PlayerID") + ";" + Socializer_SaveValue + ";" + Achiever_SaveValue + ";" + Conqueror_SaveValue+";"+ Mastermind_SaveValue+";"+ Survivor_SaveValue + ";" + Daredevil_SaveValue + ";" + Seeker_SaveValue + ";" + PrimaryType_SaveValue + ";" + SecondaryType_SaveValue + ";" +
            DamageDealt_SaveValue +";"+DamageReceived_SaveValue+";"+PlayerDeathCounter_SaveValue+";"+TotalPlayTime_SaveValue+";" +NumberOfRestarts_SaveValue+";"+CollectedPickUps_SaveValue+";"+FinalBossSpikeCounter_SaveValue+";"+FinalBossHitCounter_SaveValue+";"+IdleTime_SaveValue+";"+PerfectRun_SaveValue+";"+TimeToFinishGame_SaveValue+";"+BrokeTheGame_SaveValue+";"+MaxSpeed_SaveValue+";"+DamageReceived_Spikes_SaveValue+";" +
                GatheredHealth_SaveValue+";"+WallHits_SaveValue+";"+VasesDestroyed_SaveValue+";"+EnemiesKilled_SaveValue+";"+FoundSecretlevel_SaveValue+";"+BossKilledWithTraps_SaveValue+";"+PuzzlesSolvedCounter_SaveValue+";"+AllPuzzlesSolved_SaveValue+";"+SetTheForkOnFire_SaveValue+";" +
               ";"+SecretsFoundCounter_SaveValue+";"+BladeRun_SaveValue+";"+SteppedOnTrapsCounter_SaveValue+";"+AchievementsDoneCounter_SaveValue+";"+AllAchievementsDone_SaveValue+";"+allPlacesPlayerDied+";"+"\n");
       //PlayerPrefs.SetInt("PlayerID", PlayerPrefs.GetInt("PlayerID") + 1);
         PlayerPrefs.SetInt("PlayerID", 0);
       
    }



    private void OnApplicationQuit()
    {
        if (isRealTest)
            SaveAllData();
    }

    




}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataToSaveScript : MonoBehaviour
{
    private static DataToSaveScript Instance { get; set; }

    //
    public int playerID;
    public Button saveButton;

    //PlayerTypeValues
    public static int Socializer_SaveValue;//
    public static int Achiever_SaveValue;//
    public static int Conqueror_SaveValue;//
    public static int Mastermind_SaveValue;//
    public static int Survivor_SaveValue;//
    public static int Daredevil_SaveValue;//
    public static int Seeker_SaveValue;//
    public static string PrimaryType_SaveValue;//
    public static string SecondaryType_SaveValue;//

    //IngameDaten
    public static int DamageDealt_SaveValue;//
    public static int DamageReceived_SaveValue;//
    
   
    public static int PlayerDeathCounter_SaveValue;//
    public static float TotalPlayTime_SaveValue;//
    public static float NumberOfRestarts_SaveValue;//
    public static int CollectedPickUps_SaveValue;//
    public static int FinalBossSpikeCounter_SaveValue;//
    public static int FinalBossHitCounter_SaveValue;//

    public static float IdleTime_SaveValue;//
    public static bool PerfectRun_SaveValue=true;//
    public static List<string> LevelPlayerDied_SaveValue = new List<string>();//
    public static float TimeToFinishGame_SaveValue;//
    public static bool FinishedTheGame_SaveValue;//
    public static bool BrokeTheGame_SaveValue;//
    public static float MaxSpeed_SaveValue;//

    public static bool PlayerKeepedPlaying_SaveValue;

    //AchieveMentRelated;
    public static int DamageReceived_Spikes_SaveValue;//

    public static int GatheredHealth_SaveValue;//
    public static int WallHits_SaveValue;//
    public static int AchievementsFoundCounter_SaveValue;//
    public static int VasesDestroyed_SaveValue;//
    public static int EnemiesKilled_SaveValue;//
    public static bool FoundSecretlevel_SaveValue; //
    public static bool BossKilledWithTraps_SaveValue=true; //
    public static int PuzzlesSolvedCounter_SaveValue; //
    public static bool AllPuzzlesSolved_SaveValue; //
    public static bool SetTheForkOnFire_SaveValue; //
    public static int SecretsFoundCounter_SaveValue; //
    public static bool BladeRun_SaveValue;//
    public static int SteppedOn5TrapsCounter_SaveValue;//
    public static bool SteppedOn5Traps_SaveValue;//

    
    


    public static int  AchievementsDoneCounter_SaveValue;//
    public static bool AllAchievementsDone_SaveValue;//


   
    
    
    

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

    }


    public void Update()
    {
        TotalPlayTime_SaveValue += Time.deltaTime;
        if (DamageReceived_SaveValue != 0)
        {
            PerfectRun_SaveValue = false;
        }
        if (FinalBossHitCounter_SaveValue != 0)
        {
            BossKilledWithTraps_SaveValue = false;
        }
        if (SteppedOn5TrapsCounter_SaveValue >= 5)
        {
            SteppedOn5Traps_SaveValue = true;
        }
        if (AchievementsDoneCounter_SaveValue >= 3)
        {
            AllAchievementsDone_SaveValue = true;
        }       
    }

    void SaveAllData()
    {
        string path = Application.dataPath + "/DataToSave.txt";


        if (!File.Exists(path))
        {
            Debug.Log("SavedData");
            File.WriteAllText(path, "DataToSave\n\n");
        }
        Debug.Log("SaveButton");
    }






}
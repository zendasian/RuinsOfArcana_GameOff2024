using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PersistantDataMangaer : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string file_name;
    private FlieDataHandler file_data_handler;
    public static PersistantDataMangaer instance { get; private set; }
    private Level_data level_data;
    private List<IPersistanceManager> persistance_objects;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        this.file_data_handler = new FlieDataHandler(Application.persistentDataPath, file_name);
        this.persistance_objects = FindAllPersistanceObjects();
        LoadGame();
    }
    public void NewGame()
    {
        this.level_data = new Level_data();
    }
    public void LoadGame()
    {
        this.level_data = file_data_handler.Load();
        //TODO: Add the code to load the game
        if (this.level_data == null)
        {
            NewGame();
        }
        foreach (IPersistanceManager persistance_object in FindAllPersistanceObjects())
        {
            persistance_object.LoadData(level_data);
        }

        
    }
    public void SaveGame()
    {
        foreach (IPersistanceManager persistance_object in FindAllPersistanceObjects())
        {
            persistance_object.SaveData(ref level_data);
        }
        
        file_data_handler.Save(level_data);
    }
    private List<IPersistanceManager> FindAllPersistanceObjects()
    {
        
           IEnumerable<IPersistanceManager> persistance_objects = FindObjectsOfType<MonoBehaviour>().OfType<IPersistanceManager>();
        
        return new List<IPersistanceManager>(persistance_objects);
    }


}

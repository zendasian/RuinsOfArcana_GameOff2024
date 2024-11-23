using UnityEngine;
using System.IO;
using System;


public class FlieDataHandler
{
    private string data_dir_path = "";
    private string data_file_name = "";


    public FlieDataHandler(string data_dir_path, string data_file_name)
    {
        this.data_dir_path = data_dir_path;
        this.data_file_name = data_file_name;
    }

    public Level_data Load()
    {
        string full_path = Path.Combine(data_dir_path, data_file_name);
        Level_data loaded_data = null;
        if (File.Exists(full_path))
        {
            try
            {
                string data_to_load = "";
                using FileStream stream = new FileStream(full_path, FileMode.Open);
                using StreamReader reader = new StreamReader(stream);
                data_to_load = reader.ReadToEnd();
                loaded_data = JsonUtility.FromJson<Level_data>(data_to_load);
            }
            catch (Exception e)
            {
                Debug.LogError("no file found " + full_path + " " + e.Message);
            }   
        }
        return loaded_data;
     
    }
    public void Save(Level_data data)
    {
        string full_path = Path.Combine(data_dir_path, data_file_name);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(full_path));
            string data_to_store = JsonUtility.ToJson(data, true);
            using FileStream stream = new FileStream(full_path, FileMode.Create);
            using StreamWriter writer = new StreamWriter(stream);
            writer.Write(data_to_store);
        }
        catch (Exception e)
        {
            Debug.LogError("Error al crear el directorio: " + e.Message);
        }
    }

}

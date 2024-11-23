using UnityEngine;

public interface IPersistanceManager
{
    void LoadData(Level_data data);
    void SaveData(ref Level_data data);
    
}

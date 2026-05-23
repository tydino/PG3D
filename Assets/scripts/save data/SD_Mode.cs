using UnityEngine;

[System.Serializable]
public class SD_Mode
{
    public sd_Mode mode;
    public modes currentMode;

    public void SaveToJson()
    {
        if(currentMode == modes.easy)
        {
            mode.mode = "easy";
        }
        else if(currentMode == modes.medium)
        {
            mode.mode = "medium";
        }
        else if (currentMode == modes.hard)
        {
            mode.mode = "hard";
        }

        string data = JsonUtility.ToJson(mode);
        string filePath = SaveData.current.path + "/Mode.json";
        if (!System.IO.Directory.Exists(filePath))
        {
            System.IO.Directory.CreateDirectory(filePath);
        }
        System.IO.File.WriteAllText(filePath, data);
    }

    public void LoadFromJson()
    {
        string filePath = SaveData.current.path + "/Mode.json";
        if (System.IO.File.Exists(filePath))
        {
            string data = System.IO.File.ReadAllText(filePath);

            mode = JsonUtility.FromJson<sd_Mode>(data);

            if (mode.mode == "easy")
            {
                currentMode = modes.easy;
            }
            else if (mode.mode == "medium")
            {
                currentMode = modes.medium;
            }
            else if (mode.mode == "hard")
            {
                currentMode = modes.hard;
            }
        }
    }
}

[System.Serializable] 
public class sd_Mode
{
    public string mode;
}

public enum modes
{
    easy, medium, hard
}
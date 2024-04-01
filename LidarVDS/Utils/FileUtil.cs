using System.IO;

namespace LidarVDS.Utils;

public class FileUtil
{
    public static string runtimePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    public static string dataFolderPath = runtimePath + "\\DataFolder";
    public static string configFolderPath = runtimePath + "\\Config";
    public static string historyPath = dataFolderPath + "\\Historys";
    public static string documentsPath = dataFolderPath + "\\Documents";
    
    public static string colorFileName = "Color.yaml";
    public static string colorFilePath = configFolderPath + "\\" + colorFileName;
    public static string configFileName = "Settings.yaml";
    public static string configFilePath = configFolderPath + "\\" + configFileName;
    
    public static string load(string path)
    {
        return File.ReadAllText(path);
    }

    public static void save(string directory,string file, string content)
    {
        Directory.CreateDirectory(directory);
        File.WriteAllText(directory+"\\"+file,content);
    }
}
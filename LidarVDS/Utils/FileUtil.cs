using System.IO;

namespace LidarVDS.Utils;

public class FileUtil
{
    public static string runtimePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    public static string dataFolderPath = runtimePath + "\\DataFolder";
    public static string documentsPath = dataFolderPath + "\\Documents";

    public static string load(string path)
    {
        return File.ReadAllText(path);
    }

    public static void save(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
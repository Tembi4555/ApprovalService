using System.IO;

namespace GlobalVariables
{
    public class GlobalVariables
    {
        static string separator = Path.DirectorySeparatorChar.ToString();
        static string dbRelativeFilePath = @$"DB{separator}approval.db";
        public static string DIRECTORY_SOLUTION = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
        public string PATH_TO_DB = Path.Combine(DIRECTORY_SOLUTION, dbRelativeFilePath);
    }
}

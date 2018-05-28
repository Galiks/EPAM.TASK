using System.IO;

namespace CreateUserFileForProgramm
{
    public class CreateUserFile
    {
        /// <summary>
        /// Method <seealso cref="CreateFile"/> is used to create file.
        /// </summary>
        public void CreateFile(string pathToFile)
        {
            FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate);
            fs.Close();
        }
    }
}

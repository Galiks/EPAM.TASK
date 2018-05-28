using Entity.Person;

namespace DAOInterface
{
    public interface INote
    {
        void WriteInfo(string pathToFile, Person person);
        void ReadInfo(string pathToFile);
        void DeleteInfo(string pathToFile);
    }
}

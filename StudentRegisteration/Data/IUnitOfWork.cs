using StudentRegisteration.Repository;

namespace StudentRegisteration.Data
{
    public interface IUnitOfWork
    {
        IStudentRepository Students{ get; }
    }
}

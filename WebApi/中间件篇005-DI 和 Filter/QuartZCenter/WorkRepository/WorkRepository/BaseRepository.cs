using SqlSugar;
using QuartZ.Core;

namespace WorkRepository
{
    public class BaseRepository
    {
        public T GetInstance<T>() => IOCCollection.GetService<T>();
        public SqlSugarScope DBConne { get => GetInstance<SqlSugarScope>(); }
    }
}

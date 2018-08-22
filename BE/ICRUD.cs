namespace BE
{
    using System.Collections.Generic;
    public interface ICRUD<T>
    {
        bool Create(T ObjAlta);
        List<T> Retrive();
        bool Delete(T ObjDel);
        bool Update(T ObjUpd);
    }
}

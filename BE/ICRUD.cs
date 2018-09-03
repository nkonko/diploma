namespace BE
{
    using System.Collections.Generic;

    public interface ICRUD<T>
    {
        bool Create(T objAlta);

        List<T> Retrive();

        bool Delete(T objDel);

        bool Update(T objUpd);
    }
}

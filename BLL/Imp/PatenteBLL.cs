namespace BLL.Imp
{
    using DAL.Imp;

    public class PatenteBLL : IPatenteBLL
    {
        private readonly IPatenteDAL patenteDAL;

        public PatenteBLL(IPatenteDAL patenteDAL)
        {
            this.patenteDAL = patenteDAL;
        }
    }
}

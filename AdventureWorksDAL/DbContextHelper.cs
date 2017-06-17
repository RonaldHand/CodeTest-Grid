using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksDAL
{
    public static class DbContextHelper
    {
        public static System.Data.Entity.EntityState GetEntityState(AdventureWorksModel.ModelBase data)
        {
            ///Order of Operations: Deleted, New, Modifier, Unchanged
            ///If an object is deleted all other markers are ignored.
            ///If an object is New then Dirty is ignored
            ///If and object is not Deleted or New the IsDirty Property is Used

            if (data.IsDeleted) return System.Data.Entity.EntityState.Deleted;
            if (data.IsNew) return System.Data.Entity.EntityState.Added;
            if (data.IsDirty) return System.Data.Entity.EntityState.Modified;
            return System.Data.Entity.EntityState.Unchanged;
        }

    }
}

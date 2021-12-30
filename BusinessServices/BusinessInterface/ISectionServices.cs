using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.BusinessInterface
{
    public interface ISectionServices
    {
        IEnumerable<SectionEntity> GetAllSection();
        SectionEntity CreateSection(SectionEntity sectionEntity);
        bool UpdateSection(SectionEntity sectionEntity);
    }
}

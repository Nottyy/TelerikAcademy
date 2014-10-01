using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractStudentsGroupedByGroupNamePlusTask19
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        public static Student[] OrderByGroupName(this IEnumerable<Student> listOfStudents)
        {
            return listOfStudents.OrderBy(x => x.GroupName).ToArray();
        }
    }
}

using RomainJ.MinieBicks.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomainJ.MinieBicks.lib
{
    public class TypeCongeController
    {
        public static List<TypeConges> RechercheTousLesConges()
        {
            return TypeConges.SearchGroupTypeConges();
        }
    }
}

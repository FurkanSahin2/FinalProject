using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }

        // Vers_2: 

        //public static List<IResult> Run_2(params IResult[] locigs_2)
        //{
        //    List<IResult> errorResults = new List<IResult>();
        //    foreach (var logic_2 in locigs_2)
        //    {
        //        if (!logic_2.Success)
        //        {
        //            errorResults.Add(logic_2);
        //        }
        //    }
        //    return errorResults;
        //}
    }
}

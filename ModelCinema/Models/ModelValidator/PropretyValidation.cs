using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModelCinema.Models.ModelValidator
{
    static public class PropretyValidation
    {

        static public bool IsStringValide(string candidate, int minLength, int maxLegth)
        {
            if (candidate.Length >= minLength && candidate.Length <= maxLegth)
                return true;
            else
                return false;
        }

        static public bool IsStringValide(string candidate, int minLength, int maxLegth, string regExString)
        {
            if (candidate.Length >= minLength && candidate.Length <= maxLegth)
            {
                if (regExString != "" && regExString != null)
                {
                    try
                    {
                        var regEx = new Regex(regExString);
                        if (regEx.IsMatch(candidate))
                            return true;
                        else
                            return false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
                else
                    return true;
            }
            else
                return false;
        }

        static public bool IsNumberValide(double candidate, double minVal, double maxVal)
        {
            if (candidate >= minVal && candidate <= maxVal)
                return true;
            else
                return false;
        }

        static public bool IsDateValide(DateTime candidate, DateTime minVal, DateTime maxVal)
        {
            if (candidate >= minVal && candidate <= maxVal)
                return true;
            else
                return false;
        }
    }
}

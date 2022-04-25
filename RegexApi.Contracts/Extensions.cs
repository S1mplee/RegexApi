using RegexApi.Contracts.DTO;
using System.Collections.Generic;

namespace RegexApi.Contracts
{
    public static class Extensions
    {
        public static bool IsValidRegexFlags(this short[] flags)
        {
            var hashSet = new HashSet<short> { 0, 1, 2, 4, 512, 256, 32, 16, 8, 64 };

            foreach(var flag in flags)
            {
                if (!hashSet.Contains(flag))
                    return false;
            }

            return true;
        }
    }
}

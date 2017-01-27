using System;

namespace OfficialCommunity.Necropolis.Infrastructure
{
    public class Passport
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString("D");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class SnailsRepository
    {
        private static Dictionary<int, Snail> Snails = new Dictionary<int, Snail>(); 

        public Snail Get(int id)
        {
            return Snails[id];
        }

        public void Create(Snail snail)
        {
            if (Snails.ContainsKey(snail.Id))
                throw new Exception("Id already exists");

            Snails[snail.Id] = snail;
        }

        public void Update(Snail snail)
        {
            if (!Snails.ContainsKey(snail.Id))
                throw new Exception("Can't find snail");

            Snails[snail.Id] = snail;
        }

        public void Delete(int id)
        {
            if (!Snails.ContainsKey(id))
                throw new Exception("Can't find snail");

            Snails.Remove(id);
        }
    }
}
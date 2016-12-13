using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1
{
    public class SnailsRepository
    {
        internal static Dictionary<int, Snail> Snails = new Dictionary<int, Snail>(); 

        public Snail Get(int id)
        {
            if (!Snails.ContainsKey(id))
                throw new NotFoundException("Can't find snail");

            return Snails[id];
        }

        public void Create(Snail snail)
        {
            if (Snails.ContainsKey(snail.Id))
                throw new Exception("Id already exists"); // TODO: Should be BadRequestException

            Snails[snail.Id] = snail;
        }

        public List<Snail> Get(int page, int size)
        {
            return Snails
                .Select(kvp => kvp.Value)
                .OrderBy(s => s.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public void Update(Snail snail)
        {
            if (!Snails.ContainsKey(snail.Id))
                throw new NotFoundException("Can't find snail");

            Snails[snail.Id] = snail;
        }

        public void Delete(int id)
        {
            if (!Snails.ContainsKey(id))
                throw new NotFoundException("Can't find snail");

            Snails.Remove(id);
        }
    }
}
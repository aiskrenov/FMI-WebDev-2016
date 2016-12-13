using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1
{
    public class RacesRepository
    {
        private static Dictionary<int, Race> Races = new Dictionary<int, Race>();

        public Race Get(int id)
        {
            if (!Races.ContainsKey(id))
                throw new NotFoundException("Can't find snail");

            return Races[id];
        }

        public void Create(Race snail)
        {
            if (Races.ContainsKey(snail.Id))
                throw new Exception("Id already exists"); // TODO: Should be BadRequestException

            Races[snail.Id] = snail;
        }

        public List<Race> Get(int page, int size)
        {
            return Races
                .Select(kvp => kvp.Value)
                .OrderBy(s => s.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public void Update(Race snail)
        {
            if (!Races.ContainsKey(snail.Id))
                throw new NotFoundException("Can't find snail");

            Races[snail.Id] = snail;
        }

        public void Delete(int id)
        {
            if (!Races.ContainsKey(id))
                throw new NotFoundException("Can't find snail");

            Races.Remove(id);
        }

        public void SetSnails(int id, List<Snail> snails)
        {
            if (!Races.ContainsKey(id))
                throw new NotFoundException("Can't find snail");

            Races[id].Participants = snails;
        }
    }
}
using Isima.DAL;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class MapRepository : IDisposable
    {

        private readonly IsimaEntities _dbcontext = null;

        public MapRepository() 
            {
            _dbcontext = new IsimaEntities();
            }

        public MapRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }

        public List<MapDto> GetAllMap()
        {
            try
            {
                //Get all map data line from database 
                List<Map> mapEntities = _dbcontext.Map.ToList();
                //transform to DTO, and send to upper layer
                return mapEntities.Select(x => new MapDto
                {
                    Id = x.ID,
                    Configuration = x.Configuration
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public MapDto AddMap(MapDto map)
        {
            Map newMap = map.ToEntity();
            var mapCreated = _dbcontext.Map.Add(newMap);
            _dbcontext.SaveChanges();
            return mapCreated.ToDto();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

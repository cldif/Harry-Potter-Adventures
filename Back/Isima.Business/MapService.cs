using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class MapService
    {

        public IList<MapDto> GetAllMap()
        {
            using(MapRepository _mapRepo = new MapRepository())
            {
                return _mapRepo.GetAllMap();
            }
        }

        public MapDto AddMap(MapDto map)
        {
            if(map !=null)
            {
                using (MapRepository _mapRepo = new MapRepository())
                {
                    return _mapRepo.AddMap(map);
                }
            }
           else
            {
                throw new ArgumentNullException(nameof(map), "Map can't be null");
            }
        }


        
    }
}

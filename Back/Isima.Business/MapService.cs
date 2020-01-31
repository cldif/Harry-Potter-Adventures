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
            using(MapRepository _MapRepo = new MapRepository())
            {
                return _MapRepo.GetAllMap();
            }
        }

        public MapDto AddMap(MapDto Map)
        {
            if(Map !=null)
            {
                using (MapRepository _MapRepo = new MapRepository())
                {
                    return _MapRepo.AddMap(Map);
                }
            }
           else
            {
                throw new ArgumentNullException(nameof(Map), "Map can't be null");
            }
        }


        
    }
}

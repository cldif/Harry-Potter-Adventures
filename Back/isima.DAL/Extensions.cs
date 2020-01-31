using isima.DAL;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DAL
{
    public static class Extensions
    {
        public static Map ToEntity(this MapDto dto)
        {
            return new Map
            {
                Configuration = dto.Configuration
            };
        }

        public static MapDto ToDto(this Map entity)
        {
            if(entity != null)
            {
                return new MapDto
                {
                    Configuration = entity.Configuration
                };
            }
            return null;
     
        }
    }
}

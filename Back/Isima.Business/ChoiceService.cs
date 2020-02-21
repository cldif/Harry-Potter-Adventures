using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class ChoiceService
    {
        public ChoiceDto AddChoice(ChoiceDto choice)
        {
            using (ChoiceRepository _choiceRepo = new ChoiceRepository())
            {
                return _choiceRepo.AddChoice(choice);
            }
        }
    }
}

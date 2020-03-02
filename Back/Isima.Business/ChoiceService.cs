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
        public void DeleteChoice(int id)
        {
            using (ChoiceRepository _choiceRepo = new ChoiceRepository())
            {
                _choiceRepo.DeleteChoice(id);
            }
        }
        public List<ChoiceDto> GetAllChoices()
        {
            using (ChoiceRepository _choiceRepo = new ChoiceRepository())
            {
                return _choiceRepo.GetAllChoices();
            }
        }
    }
}

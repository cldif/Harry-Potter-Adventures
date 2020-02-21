using isima.DAL;
using Isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class ChoiceRepository : IDisposable
    {
        private readonly IsimaEntities _dbcontext = null;

        public ChoiceRepository()
        {
            _dbcontext = new IsimaEntities();
        }

        public ChoiceRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }

        public ChoiceDto AddChoice(ChoiceDto choice)
        {
            try
            {
                Choice newChoice = choice.ToEntity();
                var choiceCreated = _dbcontext.Choice.Add(newChoice);
                _dbcontext.SaveChanges();
                return choiceCreated.ToDto();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

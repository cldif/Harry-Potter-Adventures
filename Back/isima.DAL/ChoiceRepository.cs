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

        public List<ChoiceDto> GetAllChoices()
        {
            try
            {
                //Get all choice data line from database 
                List<Choice> choiceEntities = _dbcontext.Choice.ToList();
                //transform to DTO, and send to upper layer
                return choiceEntities.Select(x => new ChoiceDto
                {
                    Id = x.Id,
                    Text = x.Text,
                    CurrentScenarioId = x.CurrentScenarioId,
                    NextScenarioId = x.NextScenarioId
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void DeleteChoice(int id)
        {
            try
            {
                //Get all scenario data line from database 
                List<Choice> choiceEntities = _dbcontext.Choice.ToList();
                _dbcontext.Choice.Remove(choiceEntities.Find(x => x.Id == id));
                _dbcontext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}

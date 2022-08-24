using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string QuestionDesc { get; set; }

        public IList<AnswerDto> Answers { get; set; }


    }
}

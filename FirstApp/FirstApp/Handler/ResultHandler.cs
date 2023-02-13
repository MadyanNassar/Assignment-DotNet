using FirstApp.Models;

namespace FirstApp.Handler
{
    public class ResultHandler
    {
        public IEnumerable<Result> GetResult()
        {
            var resultList = new List<Result>();

            for (int i = 0; i <= 30; i++)
            {
                var list = new Result
                {
                    Number = i,
                    Value = getValue(i)
                };
                resultList.Add(list);
            };

            static string getValue(int i)
            {
                if ((i % 3 == 0) && (i % 5 == 0)) { return "fizz buzz"; }
                else if ((i % 3 == 0)) { return "fizz"; }
                else if ((i % 5 == 0)) { return "buzz"; }
                else return i.ToString();

            }

            return resultList;
        }
    }
}

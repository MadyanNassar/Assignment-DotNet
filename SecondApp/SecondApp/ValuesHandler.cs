
namespace SecondApp
{
    public class ValuesHandler
    {
        public double GetSum()
        {

            string[] stringArr = { "42", "1e3", "1.222", null, "-12", "test" };

            var newStringArr = stringArr
                               .Where(c => c != null && double.TryParse(c, out var val) == true)
                               .Select(x => x.Replace(".", string.Empty))
                               .ToArray();

            double[] doubleArr = Array.ConvertAll(newStringArr, s => double.Parse(s));


            return doubleArr.Sum();
        }

    }
}

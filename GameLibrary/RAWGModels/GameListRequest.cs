using System.Web;

namespace GameLibrary.RAWGModels
{
    internal class GameListRequest
    {
        public int page { get; set; }
        public int page_size { get; set; }
        public string search { get; set; }
        public bool search_precise { get; set; }
        public bool search_exact { get; set; }
        public string updated { get; set; }
        public bool exclude_additions { get; set; }
        public string ordering { get; set; }

        public string GetQueryString()
        {
            IEnumerable<string> properties = from p in GetType().GetProperties()
                                             where p.GetValue(this, null) != null
                                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(this, null).ToString());

            return string.Join("&", properties.ToArray());
        }
    }
}

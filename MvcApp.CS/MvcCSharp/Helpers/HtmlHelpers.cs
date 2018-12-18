using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcCSharp.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString BulletedList(this HtmlHelper helper, string[] values)
        {
            StringBuilder builder = new StringBuilder("<ul>");
            foreach (var value in values)
            {
                builder.Append($"<li>{value}</li>");
            }
            builder.Append("</ul>");

            return new HtmlString(builder.ToString());
        }
    }
}
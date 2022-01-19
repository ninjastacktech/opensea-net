using System.Text;
using System.Text.Encodings.Web;

namespace OpenSeaClient
{
    internal static class QueryHelpers
    {
        internal static string AddQueryString(string uri, IEnumerable<(string, string)>? queryString)
        {
            if (queryString == null)
            {
                return uri;
            }

            var num = uri.IndexOf('#');
            var text = uri;
            var value = "";
            if (num != -1)
            {
                value = uri[num..];
                text = uri[..num];
            }

            var flag = text.IndexOf('?') != -1;
            StringBuilder stringBuilder = new();
            stringBuilder.Append(text);
            foreach (var param in queryString)
            {
                stringBuilder.Append(flag ? '&' : '?');
                stringBuilder.Append(UrlEncoder.Default.Encode(param.Item1));
                stringBuilder.Append('=');
                stringBuilder.Append(UrlEncoder.Default.Encode(param.Item2));
                flag = true;
            }

            stringBuilder.Append(value);
            return stringBuilder.ToString();
        }
    }
}

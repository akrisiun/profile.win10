using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProxyKit
{
    public interface IUrlRewriter
    {
        Task<Uri> RewriteUri(HttpContext context);
    }

    public class SingleRegexRewriter : IUrlRewriter
    {
        private readonly string _pattern;
        private readonly string _replacement;
        private readonly RegexOptions _options;

        public RegexOptions Options => _options;

        public SingleRegexRewriter(string pattern, string replacement)
            : this(pattern, replacement, RegexOptions.None) { }

        public SingleRegexRewriter(string pattern, string replacement, RegexOptions options)
        {
            _pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
            _replacement = replacement ?? throw new ArgumentNullException(nameof(pattern));
            _options = options;
        }

        public Task<Uri> RewriteUri(HttpContext context)
        {
            string url = context.Request.Path + context.Request.QueryString;
            var newUri = Regex.Replace(url, _pattern, _replacement);

            if (Uri.TryCreate(newUri, UriKind.Absolute, out var targetUri))
            {
                return Task.FromResult(targetUri);
            }

            return Task.FromResult((Uri)null);
        }
    }

}
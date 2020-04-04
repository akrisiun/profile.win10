// PrefixRewriter - bonus : some other Rewriter

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProxyKit
{

    public class PrefixRewriter : IUrlRewriter
    {
        private readonly PathString _prefix;
        private readonly string _newHost;

        public PrefixRewriter(PathString prefix, string newHost)
        {
            _prefix = prefix;
            _newHost = newHost;
        }

        public Task<Uri> RewriteUri(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(_prefix))
            {
                var newUri = context.Request.Path.Value
                    .Remove(0, _prefix.Value.Length) + context.Request.QueryString;
                var targetUri = new Uri(_newHost + newUri);
                return Task.FromResult(targetUri);
            }

            return Task.FromResult((Uri)null);
        }
    }

    public class MergeRewriter : IUrlRewriter
    {
        private readonly List<IUrlRewriter> _rewriters = new List<IUrlRewriter>();
        public MergeRewriter()
        {
        }
        public MergeRewriter(IEnumerable<IUrlRewriter> rewriters)
        {
            if (rewriters == null) throw new ArgumentNullException(nameof(rewriters));

            _rewriters.AddRange(rewriters);
        }

        public MergeRewriter Add(IUrlRewriter rewriter)
        {
            if (rewriter == null) throw new ArgumentNullException(nameof(rewriter));

            _rewriters.Add(rewriter);

            return this;
        }

        public async Task<Uri> RewriteUri(HttpContext context)
        {
            foreach (var rewriter in _rewriters)
            {
                var targetUri = await rewriter.RewriteUri(context);
                if (targetUri != null)
                {
                    return targetUri;
                }
            }

            return null;
        }
    }
}

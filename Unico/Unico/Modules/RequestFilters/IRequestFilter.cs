using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Unico.Modules.RequestFilters
{
    public interface IRequestFilter
    {
        bool IsServiceRequest(string appPath);
    }

    public class ServiceRequestFilter : IRequestFilter
    {
        private List<Regex> _servicePathRegexps;

        public ServiceRequestFilter(IEnumerable<string> servicePathRegexps)
        {
            _servicePathRegexps = new List<Regex>();

            foreach (var expr in servicePathRegexps)
            {
                _servicePathRegexps.Add(new Regex(expr));
            }
        }

        public bool IsServiceRequest(string appPath)
        {
            return _servicePathRegexps.Any(r => r.IsMatch(appPath));
        }
    }
        
}
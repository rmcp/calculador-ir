using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace calculator_api.Extensions
{
    public static class CustomExtensions
    {
        public static Guid ErrorWithId(this ILogger logger, Exception ex)
        {
            var id = Guid.NewGuid();
            logger.LogError(ex.Message,"ErrorId", id);            
            
            return id;
        }
    }
}

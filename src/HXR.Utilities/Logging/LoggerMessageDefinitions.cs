using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HXR.Utilities.Logging
{
    // TODO LoggingMessageDefinitions: Complete this later
    //
    // Problem:     https://www.youtube.com/watch?v=bnVfrd3lRv8
    // Solution:    https://www.youtube.com/watch?v=a26zu-pyEyg
    public static class LoggerMessageDefinitions
    {
        private static readonly Action<ILogger, string, Exception?> LogUnitRetrievalMessageDefinition =
            LoggerMessage.Define<string>(LogLevel.Information, 100, "Attempting to retrieve data for  {unitCode}");

        public static void LogUnitRetrieval(this ILogger logger, string unitCode) {
            LogUnitRetrievalMessageDefinition(logger, unitCode, null);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiddenTruth.Library.Model;

namespace HiddenTruth.Library.Services
{
    /// <summary>
    /// Defines the service manager interface
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Loads the new dvd movies async.
        /// </summary>
        /// <returns>
        /// Represents an asynchronous operation that return a IEnumerable.
        /// </returns>
        void GetDataBlogZaSeriozniHora(string pageToken, Action<PageModel, Exception> callback);

        /// <summary>
        /// Loads the top dvd movies async.
        /// </summary>
        /// <returns>Represents an asynchronous operation that return a IEnumerable.</returns>
        void GetDataAlterInformation(string pageToken, Action<PageModel, Exception> callback);
    }
}

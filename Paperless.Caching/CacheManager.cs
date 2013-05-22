using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Paperless.Caching
{
    public class CacheManager
    {
        #region Variables
        ICacheManager _CacheManager;
        #endregion

        #region Methods

        public CacheManager()
        {
            _CacheManager = CacheFactory.GetCacheManager();
        }

        public CacheManager(string pNameCacheManager)
        {
            _CacheManager = CacheFactory.GetCacheManager(pNameCacheManager);
        }

        public void SetCacheManager(string pNameCacheManager)
        {
            _CacheManager = CacheFactory.GetCacheManager(pNameCacheManager);
        }

        public void AddItems(string pId,object pItem)
        {
            _CacheManager.Add(pId, pItem);
        }

        public void AddItems(string pId, object pItem, TimeSpan pTiempo)
        {
            var expirationTime= new AbsoluteTime(pTiempo);
            _CacheManager.Add(pId, pItem, CacheItemPriority.Normal, null, expirationTime);
        }

        public object GetItem(string pId)
        {
            
            return _CacheManager.GetData(pId);
        }


        #endregion

    }
}
